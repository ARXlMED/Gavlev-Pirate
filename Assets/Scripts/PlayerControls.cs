using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMove = 0f;
    public float speed = 1f;
    private bool facingRight = true;
    public float jumpForse = 8f;
    public bool isGrounded = false;
    public float checkGroundOffsetY = -1.1f;
    public float checkGroundRadius = 0.3f;
    public Animator animator;
    public float SX, SY;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMove));
        if(horizontalMove < 0 && facingRight)
        {
            Flip();
        }
        else if(horizontalMove > 0 && !facingRight)
        {
            Flip();
        }
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
        }
        if (isGrounded == false)
        {
            animator.SetBool("jump", true);
        }
            else 
            {
                animator.SetBool("jump", false);    
            }
//1 if (Input.GetKeyDown(KeyCode.X))
//{
//    run = run * 2;
//}

//2        if (Input.GetKeyDown(KeyCode.X))
//        {
//            run = true;
//        }
//            else 
//            {
//                run = false;
//            }
//        if (run = true)
//        {
//            speed = speed * 2;
//        }
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalMove * 2f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
    private void CheckGround()
    {
        Collider2D[] coliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);
        if(coliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
    if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "DeadZone")
        {
            transform.position = new Vector3(SX,SY, transform.position.z);
        }

    }
}
