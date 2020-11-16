using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] int maxHealth = 10;
    [SerializeField] int health;
#pragma warning restore 0649
    HealthSystemHearts healthSystem;

    #region Health

    #region Health System Calls
    public void Damage(int amount)
    {
        healthSystem.Damage(amount);
        health = (int)healthSystem.Health;
    }
    public void Heal(int amount)
    {
        healthSystem.Heal(amount);
        health = (int)healthSystem.Health;
    }
    public void AddHeart(int amount)
    {
        healthSystem.AddHeart(amount);
        health = (int)healthSystem.Health;
    }
    public void RemoveHeart(int amount)
    {
        healthSystem.RemoveHeart(amount);
        health = (int)healthSystem.Health;
    }
    #endregion

    //Event call from HealthSystem.
    void HealthSystemHearts_OnDead(object sender, System.EventArgs e)
    {
        Debug.LogWarning("Dead");
    }

    void InitHealthSystem()
    {
        healthSystem = new HealthSystemHearts(maxHealth);
        healthSystem.OnDead += HealthSystemHearts_OnDead;

        FindObjectOfType<HealthSystemHeartsUI>().SetHealthSystemHearts(healthSystem);
    }
    #endregion

    void Start()
    {
        InitHealthSystem();
    }
}
