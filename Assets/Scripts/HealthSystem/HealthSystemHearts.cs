using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemHearts : IHealthSystem
{
    public const int MAX_FRAGMENT_AMOUNT = 2;   //Maybe make

    public event EventHandler OnDamage;
    public event EventHandler OnHeal;
    public event EventHandler OnDead;
    public event EventHandler OnAddHeart;
    public event EventHandler OnRemoveHeart;

    public float MaxHealth { get; set; }
    public float Health { get; set; }
    List<Heart> heartsList;


    /// <summary>
    /// Initilizes health system.
    /// </summary>
    /// <param name="amount">Total amount of starting health.</param>
    public HealthSystemHearts(int amount)
    {
        MaxHealth = amount;
        Health = MaxHealth;
        int heartAmount = (amount / MAX_FRAGMENT_AMOUNT);

        heartsList = new List<Heart>();
        for (int i = 0; i < heartAmount; i++)
        {
            Heart heart = new Heart(MAX_FRAGMENT_AMOUNT);
            heartsList.Add(heart);
        }
    }

    public List<Heart> GetHeartsList()
    {
        return heartsList;
    }

    public void Damage(float amount)
    {
        if (Health <= 0)
            return;

        Health -= amount;
        int damageAmount = Mathf.RoundToInt(amount);

        for (int i = heartsList.Count - 1; i >= 0; i--)
        {
            Heart heart = heartsList[i];

            if (damageAmount > heart.Fragments)
            {
                damageAmount -= heart.Fragments;
                heart.Damage(heart.Fragments);
            }
            else
            {
                heart.Damage(damageAmount);
                break;
            }
        }

        OnDamage?.Invoke(this, EventArgs.Empty);    //Event call to HeathUI

        if (IsDead())
        {
            OnDead?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Heal(float amount)
    {
        if (Health >= MaxHealth)
            return;

        Health += amount;
        int healAmount = Mathf.RoundToInt(amount);

        for (int i = 0; i < heartsList.Count; i++)
        {
            Heart heart = heartsList[i];
            int missingFragments = MAX_FRAGMENT_AMOUNT - heart.Fragments;
            if (healAmount > missingFragments)
            {
                healAmount -= missingFragments;
                heart.Heal(missingFragments);
            }
            else
            {
                heart.Heal(healAmount);
                break;
            }
        }

        OnHeal?.Invoke(this, EventArgs.Empty);
    }

    public void AddHeart(float amount)
    {
        MaxHealth += amount * MAX_FRAGMENT_AMOUNT;
        Health += amount * MAX_FRAGMENT_AMOUNT;
        int heartAmount = Mathf.RoundToInt(amount);

        for (int i = 0; i < heartAmount; i++)
        {
            Heart heart = new Heart(MAX_FRAGMENT_AMOUNT);
            heartsList.Insert(0, heart);
        }

        OnAddHeart?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveHeart(float amount)
    {
        MaxHealth -= amount * MAX_FRAGMENT_AMOUNT;
        Health -= amount * MAX_FRAGMENT_AMOUNT;
        int heartAmount = Mathf.RoundToInt(amount);

        heartsList.RemoveRange(heartsList.Count - (heartAmount), heartAmount);

        OnRemoveHeart?.Invoke(this, EventArgs.Empty);
    }

    public bool IsDead()
    {
        return heartsList[0].Fragments == 0;
    }



    /*Class For Heart*/
    public class Heart
    {
        public int Fragments { get; private set; }

        public Heart(int fragments)
        {
            Fragments = fragments;
        }

        public void Damage(int damageAmount)
        {
            if (damageAmount >= Fragments)
            {
                Fragments = 0;
            }
            else
            {
                Fragments -= damageAmount;
            }
        }

        public void Heal(int healAmount)
        {
            if (Fragments + healAmount > MAX_FRAGMENT_AMOUNT)
            {
                Fragments = MAX_FRAGMENT_AMOUNT;
            }
            else
            {
                Fragments += healAmount;
            }
        }
    }
}





