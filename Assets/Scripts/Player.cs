using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] float maxHealth = 10;
#pragma warning restore 0649

    HealthSystemHearts healthSystem;

    #region Health System Calls
    public void Damage(int amount)
    {
        healthSystem.Damage(amount);
    }
    public void Heal(int amount)
    {
        healthSystem.Heal(amount);
    }
    public void AddHeart(int amount)
    {
        healthSystem.AddHeart(amount);
    }
    public void RemoveHeart(int amount)
    {
        healthSystem.RemoveHeart(amount);
    }
    #endregion

    void Start()
    {
        healthSystem = new HealthSystemHearts(maxHealth);

        FindObjectOfType<HealthSystemHeartsUI>().SetHealthSystemHearts(healthSystem);
    }
}
