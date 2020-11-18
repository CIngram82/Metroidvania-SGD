using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBomber : MonoBehaviour
{

    public static GoblinBomber goblinBomber;
    private int health;
    [SerializeField] private Animator anim;

    
    void Start()
    {
        goblinBomber = this;
        health = 5;
        anim = gameObject.GetComponent<Animator>();
    }

   public void TakeGoblinDamage()
   {

        health--;
        anim.SetBool("IsHit", true);
        
        if(health == 0)
        {
            anim.SetBool("IsDead", false);
            gameObject.SetActive(false);
        }
   }
  


}
