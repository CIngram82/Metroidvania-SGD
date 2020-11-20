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



    void Start()
    {
        goblinBomber = this;
        health = 5;
        anim = gameObject.GetComponent<Animator>();
        playerobj = GameObject.Find("Player");  
        isFinding = true;
        StartCoroutine(FindplayerLocation());
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
            
            if (distance < 2)
            {
                Debug.Log("In Range to close attack");
            }
            else if(distance < 5)
            {
                Debug.Log("In Range To Bomb");
            }
            yield return null;

        }
        yield return new WaitForSeconds(1);
    }


}
