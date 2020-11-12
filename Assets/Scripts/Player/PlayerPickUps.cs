using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUps : MonoBehaviour
{

    [SerializeField] private int coinCounter;

    private void Start()
    {
        coinCounter = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "JumpSkill")
        {
            other.gameObject.SetActive(false);
            PlayerMovement.playerMovement.jumpsAllowed = 2;
        }
        if(other.gameObject.tag == "Bomb")
        {
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Coin")
        {

            other.gameObject.SetActive(false);
            coinCounter++;
            
        }
        if(other.gameObject.tag == "Sword")
        {
            other.gameObject.SetActive(false);
            PlayerAttack.playerAttack.hasSword = true;
        }
        if(other.gameObject.tag == "HealthItem")
        {
            Debug.Log("Grabbed Health Item");
            other.gameObject.SetActive(false);
        }
    }

  

}
