using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 direction;
    [SerializeField] private ProjectileData data;

    public event Action<Collider2D> OnTriggered;

    public Vector2 Direction
    {
        get => direction;
        set => direction = value.normalized;
    }

    public int Damage
    {
        get => data.Damage;
        set
        {
            if (value >= 0f)
            {
                data.Damage = value;
            }
        }
    }

    public float Speed
    {
        get => data.Speed;
        set
        {
            if (value >= 0f)
            {
                data.Speed = value;
            }
        }
    }

    public int Pierce
    {
        get => data.Pierce;
        set
        {
            if (value >= 1)
            {
                data.Pierce = value;
            }
        }
    }

    private void Update()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = direction * data.Speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggered?.Invoke(other);
    }
}