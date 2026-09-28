using UnityEngine;

public class OnTriggerDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Life life = other.GetComponentInChildren<Life>();

        if (life != null)
        {
            life.TakeDamage(damage);
        }
    }
}
