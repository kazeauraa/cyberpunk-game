using System;
using System.Collections;
using UnityEngine;

public class Life : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 6;
    [SerializeField] private int maxHealth = 20;

    [SerializeField] private float takeHitCooldown = 0.25f;

    public int Health => health;
    public int MaxHealth => maxHealth;
    public bool IsTakingHit { get; private set; }
    public bool IsDying { get; private set; }

    public event Action OnHealthChanged;
    public event Action<int> OnTookHit;
    public event Action OnTookHitOver;
    public event Action<int> OnHealed;
    public event Action OnDied;

    public void TakeDamage(int damage)
    {
        if (!IsTakingHit && !IsDying)
        {
            health -= damage;

            if (health <= 0)
            {
                health = 0;
                IsDying = true;
                OnDied?.Invoke();
            }
            else
            {
                OnTookHit?.Invoke(damage);
                StartCoroutine(TakeHitCooldown());
            }

            OnHealthChanged?.Invoke();
        }
    }

    public bool Heal(int amount)
    {
        bool result = false;

        if (amount > 0 && health < MaxHealth && !IsDying)
        {
            health = Mathf.Min(health + amount, MaxHealth);
            OnHealthChanged?.Invoke();
            OnHealed?.Invoke(amount);

            result = true;
        }

        return result;
    }

    private IEnumerator TakeHitCooldown()
    {
        IsTakingHit = true;
        yield return new WaitForSeconds(takeHitCooldown);
        IsTakingHit = false;

        OnTookHitOver?.Invoke();
    }

    public void Revive()
    {
        health = MaxHealth;
        IsDying = false;
    }
}