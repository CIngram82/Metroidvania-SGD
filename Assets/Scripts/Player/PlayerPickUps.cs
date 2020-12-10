using UnityEngine;
using TMPro;

public class PlayerPickUps : MonoBehaviour
{
    public static PlayerPickUps playerPickups;
#pragma warning disable 0649
    [SerializeField] TextMeshProUGUI paneltext;
    [SerializeField] int coinCounter;
    [SerializeField] int bombCounter;
    [SerializeField] GameObject endPanel;
    [SerializeField] UIGameController ui;
#pragma warning restore 0649


    void Start()
    {
        playerPickups = this;
        coinCounter = 0;
        bombCounter = 0;
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "JumpSkill")
        {
            other.gameObject.SetActive(false);
            PlayerMovement.playerMovement.JumpsAllowed = 2;
        }
        if(other.gameObject.tag == "Bomb")
        {
            other.gameObject.SetActive(false);
            bombCounter++;
            PlayerBombs.playerBombs.HasBomb = true;
           
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
            PlayerAttack.playerAttack.HasSword = true;
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

    void Awake()
    {
        ui = ui ? ui : FindObjectOfType<UIGameController>();
    }
}
