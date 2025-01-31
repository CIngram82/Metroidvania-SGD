﻿using System.Collections;
using UnityEngine;

public class GoblinBomber : MonoBehaviour
{
    public static GoblinBomber goblinBomber;
#pragma warning disable 0649
    [SerializeField] private Animator anim;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject thrownBomb;
    [SerializeField] GameObject bombPickup;
#pragma warning restore 0649

    GameObject playerobj;
    int health;
    float distance;
    bool isFinding;
    bool readyBomb;


    void Start()
    {
        goblinBomber = this;
        health = 5;
        anim = gameObject.GetComponent<Animator>();
        playerobj = GameObject.Find("Player");
        isFinding = true;
        StartCoroutine(FindplayerLocation());
        readyBomb = true;
    }


    //used in the player attack script when sphere overlap detects boss on enemy layer.
    public void TakeGoblinDamage()
    {

        health--;
        anim.Play("Bomber_Goblin_Hit");

        if (health == 0)
        {
            isFinding = false;
            anim.SetBool("IsDead", true);
            Vector2 bombPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - .8f);
            thrownBomb = Instantiate(bombPickup, bombPosition, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }


    IEnumerator FindplayerLocation()
    {

        while (isFinding)
        {

            distance = Vector3.Distance(gameObject.transform.position, playerobj.transform.position);
            anim.SetFloat("Distance", distance);
            if (distance < 7 && readyBomb)
            {
                readyBomb = false;
                anim.SetFloat("Distance", distance);
                Vector2 bombPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1.2f);
                thrownBomb = Instantiate(bombPrefab, bombPosition, Quaternion.identity);
                Rigidbody2D bombRig = thrownBomb.GetComponent<Rigidbody2D>();
                bombRig.AddRelativeForce(-transform.right * distance, ForceMode2D.Impulse);
                float bombTime = Random.Range(1, 3);
                Invoke("AllowBomb", bombTime);
            }
            yield return null;

        }
        yield return new WaitForSeconds(1);
    }

    void AllowBomb()
    {
        readyBomb = true;
    }



}

