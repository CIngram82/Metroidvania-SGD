using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUps : MonoBehaviour
{

    public static PlayerPickUps playerPickups;
    [SerializeField] private int coinCounter;
    [SerializeField] private int bombCounter;
    

    private void Start()
    {
        playerPickups = this;
        coinCounter = 0;
        bombCounter = 0;
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
            bombCounter++;
            PlayerBombs.playerBombs.hasBomb = true;
           
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
            gameObject.GetComponent<Player>().Heal(1);
            other.gameObject.SetActive(false);
        }
    }

  

}
