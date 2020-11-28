using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombs : MonoBehaviour
{
    public static PlayerBombs playerBombs;
    public bool hasBomb;
    // public int bombCounter;
    [SerializeField] GameObject bombPrefab;
    AudioManager audioManager;


    void Start()
    {
        playerBombs = this;
        hasBomb = false;
        audioManager = AudioManager.AM;
    }

 
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && hasBomb)
        {
            Instantiate(bombPrefab, transform.position + (transform.forward), transform.rotation);
            Debug.Log("canPlace");
            hasBomb = false;
           // audioManager.Play(audioManager.GetSFX(), "bomb_", Random.Range(0,3));
            Invoke("ReloadBomb", 2);
        }
       
    }

   void ReloadBomb()
    {
        hasBomb = true;
    }

}
