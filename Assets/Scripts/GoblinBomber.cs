using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBomber : MonoBehaviour
{

    public static GoblinBomber goblinBomber;
    private int health;
    [SerializeField] private Animator anim;
    private GameObject playerobj;
    private GameObject thisObject;
    private float distance;
    private bool isFinding;
    [SerializeField] GameObject bombPrefab;
    
   [SerializeField] GameObject thrownBomb;
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

   public void TakeGoblinDamage()
   {

        health--;
        anim.SetBool("IsHit", true);
        
        if(health == 0)
        {
            isFinding = false; 
            anim.SetBool("IsDead", false);
            gameObject.SetActive(false);
        }
   }


    IEnumerator FindplayerLocation()
    {

        while (isFinding) 
        {

            distance = Vector3.Distance(gameObject.transform.position, playerobj.transform.position);  
            
            if(distance < 7 && readyBomb)
            {
                readyBomb = false;
                anim.SetFloat("Distance", distance);
                Vector2 bombPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1.2f);
                thrownBomb = Instantiate(bombPrefab, bombPosition, Quaternion.identity);
                thrownBomb.GetComponent<Rigidbody2D>().AddRelativeForce(transform.forward * 10.0f, ForceMode2D.Impulse);
                Invoke("AllowBomb", 1.5f);
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

