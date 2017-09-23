using UnityEngine;
using System.Collections;

public abstract class EnemyAI : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;
    protected Animator anim;

    //protected Transform targetPlayer;
    public float speed;
    public float detectRange;
    public float minDist; //how close the enemy should get to the player
    public LayerMask playerLayers;

    protected bool wandering;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine("Wander");
    }

    private IEnumerator Wander()
    {
        wandering = true;
        while (true)
        {
            while (wandering)
            {
                float newXPos = Random.Range(transform.position.x - detectRange, transform.position.x + detectRange);
                Debug.Log("Wandering to " + newXPos + " from " + transform.position.x);
                while (Mathf.Abs(newXPos - transform.position.x) > 0.1)
                {
                    Debug.Log("Wandering to " + newXPos);
                    MoveTo(new Vector2(newXPos, 0));
                    yield return new WaitForFixedUpdate();
                }
                Debug.Log("Wandered to " + newXPos);
                yield return new WaitForSeconds(Random.Range(2.0f, 2.0f));
            }
            while (!wandering) //Wait to wander
            {
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    protected void MoveTo (Vector2 target)
    {
        if (!anim.GetBool("Walking"))
        {
            anim.SetBool("Walking", true);
        }
        if (target.x - transform.position.x > minDist)
        {
            //Target is to the right
            if (sprite.flipX)
            {
                sprite.flipX = false;
            }

            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (target.x - transform.position.x < -minDist)
        {
            //Target is to the left
            if (!sprite.flipX)
            {
                sprite.flipX = true;
            }

            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
}