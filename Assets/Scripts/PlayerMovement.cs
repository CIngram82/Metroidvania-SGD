using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;
    private Rigidbody2D ridg;
    private SpriteRenderer rend;
    private Animator anim;
    [SerializeField] private float speed;
    private bool canJump;
   [SerializeField] private float jumpForce;
    private int jumpCount = 1;
    public int jumpsAllowed;
   [SerializeField] private LayerMask groundLayer;
    float yMovement;
  
    
    void Start()
    {
        playerMovement = this;
        jumpsAllowed = 1;
        ridg = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canJump = true;
        speed = 5;
        jumpForce = 6f;
    }

    void Update()
    {
        CheckJumping();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        ridg.velocity = new Vector2(moveHorizontal * speed, ridg.velocity.y);
        anim.SetFloat("Move", Mathf.Abs(moveHorizontal));
        yMovement = ridg.velocity.y;
        anim.SetFloat("yMovement", yMovement);

        if (moveHorizontal < 0)
        {
            rend.flipX = true; 
        }
        else if(moveHorizontal > 0)
        {
            rend.flipX = false;
        }

    }

    void CheckJumping() 
    {

        
        if (Input.GetKey(KeyCode.Space))
        {
            IsGrounded();
            if (canJump && jumpCount <= jumpsAllowed)
            {
                anim.Play("Before_Jump");

            }

        }
               
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            IsGrounded();
            if (canJump && jumpCount <= jumpsAllowed)
            {
                anim.SetBool("JumpkeyPressed", true);
                if (jumpCount == 1)
                {
                    jumpForce = 6f;
                    ridg.velocity = new Vector2(ridg.velocity.x, jumpForce);
                }
                // jumpCount++;
                if (jumpCount >= 2)
                {
                    jumpForce = 8f;
                    ridg.velocity = new Vector2(ridg.velocity.x, jumpForce);
                }
                // ridg.velocity = new Vector2(ridg.velocity.x, jumpForce);
                jumpCount++;
            }
            else
            {
                canJump = false;
            }

        }
        else
        {
            anim.SetBool("JumpkeyPressed", false);
        }

    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 1, Color.red, 2f);
        if(hitInfo.collider != null)
        {
            canJump = true;
            
            jumpCount = 1;
            return true;
        }
        return false;
    }

}
