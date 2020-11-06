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
    private bool isOnGround;
    private float jumpForce;
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
        isOnGround = true;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGrounded();
            if (isOnGround && jumpCount <= jumpsAllowed)
            {
               if(jumpCount == 1)
                {
                    //Need to set the anim of before jump to start by velocity y check, then transition to jump up after it is finished for the diration of the jump
                }
                jumpCount++;
                ridg.velocity = new Vector2(ridg.velocity.x, jumpForce);
               
            }
            else
            {
                isOnGround = false;

            }

        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("jumpButtonDown", false);
        }
       
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 1, Color.red, 2f);
        if(hitInfo.collider != null)
        {
            isOnGround = true;
            
            jumpCount = 1;
            return true;
        }
        return false;
    }

}
