using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static PlayerDeath playerDeath;
#pragma warning disable 0649
    [SerializeField] GameObject deathPanel;
#pragma warning restore 0649

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
