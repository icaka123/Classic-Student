using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject restartText;
    bool grounded=true;
    public Transform groundCheck;
    public Rigidbody2D rb;
    public float maxSpeed = 20f;
    bool facingRight = true;
    Animator anim;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700;
    bool Death;


    void Start () 
    {
		anim=GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Death = true;
        }
    }
    void FixedUpdate()
    {if (Death == true)
            return;
            anim.SetFloat("vSpeed", rb.velocity.y);
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
            if (move > 0 && !facingRight) { Flip(); }

            else if (move < 0 && facingRight) { Flip(); }
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Ground", grounded);


       
    }
    void Update()
    {
        
            if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("Ground", false);
           rb.AddForce(Vector2.up * jumpForce);

        }

            if (Death == true)
            {
    
                anim.SetBool("Death", Death);

       
                Application.LoadLevel(0);
           
       
        }
        
       
    }
    void Flip()
    {
        
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        
    }

    void Falling()
    {
        if (maxSpeed > 12)
        {
            Death = true;
        }
    }
 
}
