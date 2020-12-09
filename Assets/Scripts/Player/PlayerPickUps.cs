using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPickUps : MonoBehaviour
{

    public static PlayerPickUps playerPickups;
    [SerializeField] private int coinCounter;
    [SerializeField] private int bombCounter;
    [SerializeField] GameObject endPanel;
    public TextMeshProUGUI paneltext;
    [SerializeField] UIGameController ui;
    

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
            ui.UpdateCoinsText(coinCounter);
            
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
        if(other.gameObject.tag == "Cursed")
        {
            gameObject.GetComponent<Player>().Damage(2);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Treasure")
        {
            paneltext.text = "You found the Treasure! You Win!";
            endPanel.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }

  

}
