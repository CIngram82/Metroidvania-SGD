using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;
    [SerializeField] private Rigidbody2D ridg;
    [SerializeField] private float speed;
    private bool isOnGround;
    private float jumpForce;
    private int jumpCount = 1;
    public int jumpsAllowed;
   [SerializeField] private LayerMask groundLayer;
    
    void Start()
    {
        playerMovement = this;
        jumpsAllowed = 1;
        ridg = gameObject.GetComponent<Rigidbody2D>();
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
    }

    void CheckJumping() 
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGrounded();
            if (isOnGround && jumpCount <= jumpsAllowed)
            {
                jumpCount++;
                ridg.velocity = new Vector2(ridg.velocity.x, jumpForce);
            }
            else
            {
                isOnGround = false;
            }

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
