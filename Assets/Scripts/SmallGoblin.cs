﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGoblin : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float movement;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer rend;
    bool chasing;
    [SerializeField] LayerMask groundLayer;
    Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        movement = 1;
        chasing = false;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        direction = transform.right;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!chasing)
        {
            IsBlocked();
            rig.velocity = new Vector2(movement * speed, rig.velocity.y);
            anim.SetFloat("speed", speed);
        }

        if (movement < 0)
        {
            rend.flipX = true;
        }
        else if (movement > 0)
        {
            rend.flipX = false;
        }
    }


    bool IsBlocked()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, 1, groundLayer);
        Debug.DrawRay(transform.position,  direction * 1, Color.red, 2f);
        if (hitInfo.collider != null)
        {
            if (movement == 1f)
            {
                direction = -transform.right;
                movement = -1;
                Debug.Log(direction);
                
            }
            else
            {
                movement = 1;
                direction = transform.right;
            }
            return true;
        }
        return false;
    }
}