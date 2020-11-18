using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombs : MonoBehaviour
{

    public static PlayerBombs playerBombs;
    public bool hasBomb;
    // public int bombCounter;
    [SerializeField] GameObject bombPrefab;
    
    void Start()
    {
        playerBombs = this;
        hasBomb = false;
    }

 
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && hasBomb)
        {
            Instantiate(bombPrefab, transform.position + (transform.forward), transform.rotation);
            Debug.Log("canPlace");
            hasBomb = false;

        }
       
    }

   

}
