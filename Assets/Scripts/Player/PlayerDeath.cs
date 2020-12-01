using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static PlayerDeath playerDeath;
    [SerializeField] GameObject deathPanel;

    void Start()
    {
        playerDeath = this;
        Time.timeScale = 1;
    }
    public void  OnPlayerDeath()
  {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
  }
 
}
