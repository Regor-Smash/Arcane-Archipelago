using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    CharacterManager charMan;
    SpriteRenderer sprite;
    CharacterSheet stats;
    
    public bool isFacingRight { get; private set; }
    //bool grounded;
    int jumps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        sprite = GetComponent<SpriteRenderer>();
        stats = GetComponent<PersonalManager>().characterStats;
    }

    void Update()
    {
        if (GetComponentInParent<PersonalManager>().isActiveChar)
        {
            if (Input.GetButtonDown("Jump") && jumps > 0)
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        if (GetComponentInParent<PersonalManager>().isActiveChar)
        {
            if (Input.GetButton("Horizontal"))
            {
                GetComponent<Animator>().SetBool("Walking", true);

                if (Input.GetAxis("Horizontal") > 0)
                {
                    MoveRight();
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    MoveLeft();
                }
            }
            else if (GetComponent<Animator>().GetBool("Walking"))
            {
                GetComponent<Animator>().SetBool("Walking", false);
            }
        }
    }

    #region GroundedCollisions
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            //grounded = true;
            jumps = stats.jumpNum;
        }
    }

    /*void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }*/
    #endregion

    public void Jump()
    {
        //rb.AddForce(new Vector2(0, stats.jump), ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, stats.jumpSpeed);
        jumps--;
    }

    public void MoveRight()
    {
        if (!isFacingRight)
        {
            isFacingRight = true;
            sprite.flipX = false;
        }

        rb.velocity = new Vector2(stats.speed, rb.velocity.y);
    }

    public void MoveLeft()
    {
        if (isFacingRight)
        {
            isFacingRight = false;
            sprite.flipX = true;
        }

        rb.velocity = new Vector2(-stats.speed, rb.velocity.y);
    } 
}
