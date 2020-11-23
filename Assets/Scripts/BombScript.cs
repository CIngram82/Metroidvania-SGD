﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private LayerMask bombLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject player ;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void BombExploded()
    {
      
        Collider2D bombWallCollider;
        bombWallCollider = Physics2D.OverlapCircle(transform.position, 1.5f, bombLayer);

    
        if (bombWallCollider != null)
        {
              bombWallCollider.gameObject.SetActive(false);
        }
        GetComponent<Animator>().SetBool("hasExploded", true);
        Destroy(gameObject);

    }

    public void BombCanHitPlayer()
    {
        Collider2D playerCollider;
        playerCollider = Physics2D.OverlapCircle(transform.position, 1.5f, playerLayer);

        if (playerCollider != null)
        {
            Debug.Log("Do Damage to the Player");
            player.GetComponent<Player>().Damage(1);
        }
        GetComponent<Animator>().SetBool("hasExploded", true);
    }
}
