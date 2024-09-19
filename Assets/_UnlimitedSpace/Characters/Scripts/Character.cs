using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private Health _health;

    public bool IsDead { get; private set; } = false;

    public void TakeDamage(int damage)
    {
        _health.DecreaseValue(damage);
    }

    protected void SetCurrentHealth()
    {

    }

    protected void SetMaxHealth()
    {

    }

}
