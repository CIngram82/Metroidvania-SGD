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
    bool canAttack;

    void Start()
    {
        canAttack = true;
        playerAttack = this;
        hasSword = false;
        anim = GetComponent<Animator>();
    }

 
    private void Update()
    {
        if (hasSword == true && Input.GetMouseButtonUp(0) && canAttack)
        {
            canAttack = false;
            anim.Play("Sword_Attack");
            // swordCollider.SetActive(true);
            Invoke("AttackCooldown", .5f);
           
        }
    }

    private void SwordHit()
    {
        Debug.Log("Hit");
        // this will possibly turn off a collider
        
    }

    private void AttackCooldown()
    {
        canAttack = true;
    }

}
  
