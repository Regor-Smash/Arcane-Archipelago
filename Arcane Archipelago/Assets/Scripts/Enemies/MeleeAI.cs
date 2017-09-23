using UnityEngine;
using System.Collections;

public class MeleeAI : EnemyAI
{
    public float damage;
    public float attackSpeed;
    float lastAttack;
    bool canAttack
    {
        get
        {
            if (lastAttack + attackSpeed > Time.time)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    void DamagePlayer(Health health)
    {
        Debug.Log(gameObject.name + " dealt " + damage.ToString() + " damage to " + health.gameObject.name);
        anim.SetTrigger("Attacking");
        health.TakeDamage(damage);
        lastAttack = Time.time;
    }

    private void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, detectRange, playerLayers);
        if (col != null && !tryingToAttack)
        {
            StartCoroutine("AttackLogic", col.GetComponent<Health>());
        }
        else if (col == null && !wandering)
        {
            wandering = true;
        }
    }

    private bool tryingToAttack = false;
    IEnumerator AttackLogic(Health player)
    {
        wandering = false;
        tryingToAttack = true;
        Debug.Log(gameObject.name + "is attacking " + player.name + ". (Melee AI)");
        while (player.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > minDist) //Move into attacking range
            {
                //Debug.Log("Moving to " + transform.position + ", Dist=" + Vector3.Distance(transform.position, player.transform.position));
                MoveTo(player.transform.position);
            }
            else if (canAttack) //Attack when attack is ready (every fireRate seconds)
            {
                if (anim.GetBool("Walking"))
                {
                    anim.SetBool("Walking", false);
                }
                DamagePlayer(player);
            }
            yield return new WaitForFixedUpdate();
        }
        tryingToAttack = false;
    }
}
