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
    [SerializeField] private LayerMask cutLayer;
    AudioManager audioManager;
   


    void Start()
    {
        canAttack = true;
        playerAttack = this;
        hasSword = false;
        anim = GetComponent<Animator>();
        audioManager = AudioManager.AM;
    }


    private void Update()
    {
        if (hasSword == true && Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            CheckingForEnemyCollision();
            CheckForVineCollisions();
            canAttack = false;
            anim.Play("Sword_Attack");
            anim.SetBool("isSwinging", true);
            audioManager.Play(audioManager.GetSFX(), "sword_", Random.Range(0, 3));
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
        anim.SetBool("isSwinging", false);
    }

    void CheckingForEnemyCollision() // Enemy's have to be set up on an enemy layer for this to work on it.
    {
        Collider2D enemyCollider;
        enemyCollider = Physics2D.OverlapCircle(transform.position, 1.5f, enemyLayer);

        if(enemyCollider!= null && enemyCollider.tag == "Boss")
        {
            GoblinBomber.goblinBomber.TakeGoblinDamage();
        }
        else if (enemyCollider != null && enemyCollider.tag == "SmallGoblin")
        {
            SmallGoblin.smallGoblin.TakeSmallGoblinDamage();
        }
        else if (enemyCollider!= null)
        {
            Debug.Log(enemyCollider.gameObject.name);
            enemyCollider.gameObject.SetActive(false);
        }
      
    }

    void CheckForVineCollisions()
    {
        Collider2D VineWallCollider;
        VineWallCollider = Physics2D.OverlapCircle(transform.position, 1.5f, cutLayer);
        if (VineWallCollider != null)
        {
            Debug.Log(VineWallCollider.gameObject.name);
            audioManager.Play(audioManager.GetSFX(), "leaves_");
            VineWallCollider.gameObject.SetActive(false);
        }
    }

   

}
  
