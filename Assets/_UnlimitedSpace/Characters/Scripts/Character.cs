using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private Health _health;

    public Action<int> DamageTaken;
    public Action Died;

    public bool IsDead { get; private set; } = false;

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        if (_health.TryDecreaseValue(damage))
        {
            DamageTaken?.Invoke(damage);
        }

        if (_health.CurrentValue <= 0)
        {
            IsDead = true;
            Died?.Invoke();
        }
    }

    protected virtual void Initialize(int maxHealth, int currentHealth)
    {
        _health = new Health(maxHealth, currentHealth);
    }

    protected void HealToMaxHealth()
    {
        _health.SetValueToMax();
    }

    protected void SetDeadStatus(bool isDead)
    {
        IsDead = isDead;
    }
}
