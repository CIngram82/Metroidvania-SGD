using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombs : MonoBehaviour
{
    public static PlayerBombs playerBombs;
    public bool hasBomb;
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
            Invoke("ReloadBomb", 2);
        }
       
    }

   void ReloadBomb()
    {
        hasBomb = true;
    }

}
