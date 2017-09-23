using UnityEngine;
using System.Collections;

public class SquadTactics : MonoBehaviour
{
    public enum TacticsList { Stay, Follow, Attack, Other }
    public static TacticsList currentTactic;

    private bool inactive;
    private static GameObject activeCharacter;
    
    private Movement move;
    private AttackInterface attack;

    private float proximity //How close should the AI try to get to the player (when folowing)
    {
        get
        {
            return 2;
        }
    }
    private float senseDist //How close something needs to be for the AI to detect it
    {
        get
        {
            return 5;
        }
    }

    public LayerMask enemyLayers;

    private void Awake()
    {
        CharacterManager.ChangedActiveCharacter += UpdateActiveCharacter;
        move = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        if(activeCharacter == null)
        {
            Debug.LogWarning("There is no Active Character!", this);
            return;
        }

        if (inactive)
        {
            if (currentTactic == TacticsList.Stay)
            {
                //Do nothing
                return;
            }
            else if (currentTactic == TacticsList.Follow || currentTactic == TacticsList.Attack && attack == null)
            {
                //Go to the player
                MoveToTarget(activeCharacter.transform.position);
            }
            else if (currentTactic == TacticsList.Attack && !tryingToAttack)
            {
                //Attack all enemies within range, then go to player
                Collider2D col = Physics2D.OverlapCircle(transform.position, senseDist, enemyLayers);
                if (col != null)
                {
                    //Attack the enemy
                    StartCoroutine("AttackEnemy", col.GetComponent<EnemyHealth>());
                    return; //nothing for now
                }
                else
                {
                    //No enemies so move toward player
                    MoveToTarget(activeCharacter.transform.position);
                }
            }
        }
    }

    private void UpdateActiveCharacter(GameObject character)
    {
        if (character == gameObject)
        {
            //activeCharacter = null;
            inactive = false;
            activeCharacter = gameObject;
        }
        else
        {
            inactive = true;
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        if (target.x - transform.position.x > proximity)
        {
            //Active character is to the right
            move.MoveRight();
        }
        else if (target.x - transform.position.x < -proximity)
        {
            //Active character is to the left
            move.MoveLeft();
        }
    }

    private bool tryingToAttack = false;
    IEnumerator AttackEnemy (EnemyHealth enemy)
    {
        tryingToAttack = true;
        Debug.Log(gameObject.name + "is attacking " + enemy.name + ". (Squad Tactics)");
        while (enemy != null)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) > attack.range) //Move into attacking range
            {
                MoveToTarget(enemy.transform.position);
            }
            else if (attack.canAttack) //Attack when attack is ready (every fireRate seconds)
            {
                attack.Attack();
            }
            yield return new WaitForFixedUpdate();
        }
        tryingToAttack = false;
    }

    private void OnDestroy()
    {
        CharacterManager.ChangedActiveCharacter -= UpdateActiveCharacter;
    }
}
