using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack playerAttack;
    private Animator anim;
   // [SerializeField] private GameObject swordCollider;

    public bool hasSword;
    void Start()
    {
        playerAttack = this;
        hasSword = false;
        anim = GetComponent<Animator>();
    }

 
    private void Update()
    {
        if (hasSword == true && Input.GetMouseButtonUp(0))
        {
            anim.Play("Sword_Attack");
           // swordCollider.SetActive(true);
            Invoke("finishAttacking", .5f);
        }
    }

    private void finishAttacking()
    {
        // this will possibly turn off a collider
    }

}
  
