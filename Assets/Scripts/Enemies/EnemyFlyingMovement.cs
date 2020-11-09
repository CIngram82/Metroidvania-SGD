using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D rb2D;
    private Animator anim;
    private bool readyToAttack = false;
    private GameObject playerGO;
    private bool moveUpToAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        // is the player above me
        moveUpToAttack = transform.position.y < playerGO.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (!readyToAttack)
        {
            // With in 0.25 of player center on the y? 
            if(Mathf.Abs(transform.position.y -playerGO.transform.position.y) < 0.25f)
            {
                readyToAttack = true;
                // face the players direction
                transform.localScale = new Vector2( (transform.position.x < playerGO.transform.position.x) ? 1f : -1f, 1f);
               
            }
        }
    }
    private void FixedUpdate()
    {
        if (readyToAttack)
        {
            moveOnX();
        }
        else
        {
            moveOnY();
        }
    }


    private void moveOnY()
    {
        rb2D.velocity = new Vector2(0f, moveUpToAttack? moveSpeed : -moveSpeed);
    }
    private void moveOnX()
    {
        rb2D.velocity = new Vector2((transform.localScale.x > 0) ? moveSpeed : -moveSpeed, 0f);
    }

}
