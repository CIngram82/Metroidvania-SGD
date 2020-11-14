using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAttack : MonoBehaviour
{

    public static PlayerAttack playerAttack;
    private Animator anim;
    public bool hasSword;
    bool canAttack;
    [SerializeField] private LayerMask enemyLayer;
   


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
            CheckingForEnemyCollision();
            canAttack = false;
            anim.Play("Sword_Attack");
            Invoke("AttackCooldown", .5f);
        }
    }

    private void SwordHit()
    {
        Debug.Log("Hit");  
    }

    private void AttackCooldown()
    {
        canAttack = true;
    }

    void CheckingForEnemyCollision() // Enemy's have to be set up on an enemy layer for this to work on it.
    {
        Collider2D enemyCollider;
        enemyCollider = Physics2D.OverlapCircle(transform.position, 1.5f, enemyLayer);

        if(enemyCollider!= null)
        {
            
                Debug.Log(enemyCollider.gameObject.name);
                enemyCollider.gameObject.SetActive(false);
            
           
        }

        
       
    }

}
  
