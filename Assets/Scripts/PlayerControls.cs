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
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
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
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
}
