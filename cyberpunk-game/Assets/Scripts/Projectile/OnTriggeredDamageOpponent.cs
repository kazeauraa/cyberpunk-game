using System.Linq;
using UnityEngine;

public class OnTriggeredDamageOpponent : MonoBehaviour
{
    [SerializeField] private Projectile bullet;
    [SerializeField] private string[] triggerTags;

    private void OnEnable()
    {
        if (bullet != null)
        {
            bullet.OnTriggered += HandleTriggered;
        }
    }

    private void OnDisable()
    {
        if (bullet != null)
        {
            bullet.OnTriggered -= HandleTriggered;
        }
    }

    private void HandleTriggered(Collider2D collision)
    {
        if (triggerTags.Contains(collision.tag))
        {
            collision.GetComponentInChildren<IDamageable>().TakeDamage(bullet.Damage);
        }
    }
}