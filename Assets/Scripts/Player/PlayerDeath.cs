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
        gameObject.GetComponent<Animator>().SetTrigger("IsDead");
        deathPanel.SetActive(true);
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }
 
}
