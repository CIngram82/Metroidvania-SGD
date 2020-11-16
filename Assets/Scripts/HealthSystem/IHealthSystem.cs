using System;

public interface IHealthSystem
{
    event EventHandler OnDamage;
    event EventHandler OnHeal;
    event EventHandler OnDead;

    float MaxHealth { get; set; }
    float Health { get; set; }

    void Heal(float amount);
    void Damage(float amount);
    bool IsDead();
}





