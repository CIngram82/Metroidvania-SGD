using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUps : MonoBehaviour
{

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
    }

  

}
