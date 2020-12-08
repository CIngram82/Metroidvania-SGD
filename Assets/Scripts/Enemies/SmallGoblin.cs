using System.Collections;
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
    [SerializeField] private LayerMask playerLayer;
    Vector2 direction;
   [SerializeField] float distance;
    bool isFinding;
    private GameObject playerobj;
    bool canAttack;
    int health;

    void Start()
    {
        playerobj = GameObject.Find("Player");
        isFinding = true;
        canAttack = true;
        movement = 1;
        chasing = false;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        direction = transform.right;
        StartCoroutine(FindplayerLocation());
        health = 2;
    }

    private void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, playerobj.transform.position);
        anim.SetFloat("Distance", distance);
        CheckingDistance();

        if (movement < 0)
        {
            rend.flipX = true;
        }
        else if (movement > 0)
        {
            rend.flipX = false;
        }
     
    }

    bool IsBlocked() //Checks if there is anything on the sides of it blocking it's path that belongs to the ground layer. This does not check underneath it. Depending on the direction it's going it will change directions when blocked.
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, 1, groundLayer);
        
        Debug.DrawRay(transform.position,  direction * 1, Color.red, 2f);
        if (hitInfo.collider != null)
        {
           
            if (movement == 1f)
            {
                direction = -transform.right;
                movement = -1;
            }
            else
            {
                movement = 1;
                direction = transform.right;
            }
            Debug.Log(movement);
            return true;
        }
           
        return false;
    }

    bool CanSeePlayer() // used when checking collider in FindPlayerLocation, if the player is in the colldier range then it will check if it is in front of the player, if it isnt it will flip the direction and transform so it is facing the player.
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, 1, playerLayer);
        Debug.DrawRay(transform.position, direction * 1, Color.blue, 2f);

        if (hitInfo.collider == null && IsBlocked() == false)
        {

            if (movement == 1f)
            {
                direction = -transform.right;
                movement = -1;
            }
            else
            {
                movement = 1;
                direction = transform.right;
            }
        }

        return false;
    }

    void CheckingDistance()
    {
         if (distance >= 3)
         {
            IsBlocked();
            chasing = false;
         }
        else if (distance < 3 && IsBlocked() == false)
        {

            chasing = true;
            rig.velocity = new Vector2(distance * movement, rig.velocity.y);
        }
        if (!chasing)
         {
            IsBlocked();
            rig.velocity = new Vector2(movement * speed, rig.velocity.y);
            anim.SetFloat("speed", speed);
         }
       

    }

    IEnumerator FindplayerLocation()
    {

        while (isFinding)
        {
           
            if (distance < 1 && canAttack)
            {
                canAttack = false;
                Collider2D playerCollider;
                playerCollider = Physics2D.OverlapCircle(transform.position, 1.5f, playerLayer);

                if (playerCollider != null)
                {
                    chasing = false;
                    // CanSeePlayer();
                    IsBlocked();
                   if(IsBlocked() == false)
                   {
                        CanSeePlayer();
                   }
            
                    playerobj.GetComponent<Player>().Damage(1);
                    playerobj.GetComponent<Animator>().SetTrigger("isHit");
                }
                Invoke("DoneAttacking", 1);
            }
            yield return null;

        }
        yield return new WaitForSeconds(1);
    }

    public void DoneAttacking()
    {
        canAttack = true;
    }

    //used in the player attack script when sphere overlap detects SmallGoblin on enemy layer.
    public void TakeSmallGoblinDamage()
    {
        anim.SetTrigger("Hit");
        Debug.Log("Goblin Life" + health);
        health--;
       
        if (health <= 0)
        {
            Debug.Log("Dead");
            isFinding = false;
            anim.SetTrigger("Dead");
            gameObject.SetActive(false);
        }
    }

}
