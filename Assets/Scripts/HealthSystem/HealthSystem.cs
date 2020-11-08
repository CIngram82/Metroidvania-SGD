using System;
using UnityEngine;

public class HealthSystem<T> where T: IHealthSystem
{
    public event EventHandler OnDamage;
    public event EventHandler OnHeal;
    public event EventHandler OnDead;


    public float MaxHealth { get; private set; }
    public float Health { get; private set; }



    public HealthSystem(float healthAmount)
    {
        MaxHealth = healthAmount;
        Health = MaxHealth;
    }

    public void HealthUP(float healthAmount)
    {
        MaxHealth += healthAmount;
    }

    public void Damage(float damageAmount)
    {
        Debug.Log("damages");

        Health -= damageAmount;

        OnDamage?.Invoke(this, EventArgs.Empty);    //Event call to HeathUI

        if (IsDead())
        {
            OnDead?.Invoke(this, EventArgs.Empty);
        }

    }

    public void Heal(float healAmount)
    {
        /*
        
        */

        Health += healAmount;

        OnHeal?.Invoke(this, EventArgs.Empty);
    }

    public bool IsDead()
    {
        return Health <= 0; //heartsList[0].GetFragmentsAmount() == 0;
    }




}
