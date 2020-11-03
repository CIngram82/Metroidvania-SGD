using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private Rigidbody2D ridg;
    private float speed = 15;
    private bool isOnGround;
    private float jumpForce = 10;
    private int jumpCount = 0;
    
    void Start()
    {
        ridg = gameObject.GetComponent<Rigidbody2D>();
        isOnGround = true;
    }

   
    void Update()
    {
       
       CheckJumping();
    }

    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        ridg.AddForce(movement * speed);

    }

    void CheckJumping() // Hoping to change this to raycasting to check for ground as soon as I remember how to do it.
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isOnGround && jumpCount <= 1)
            {
                jumpCount++;
                Debug.Log("CanJump");
                ridg.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                isOnGround = false;

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            jumpCount = 0;
        }
    }
}
