using UnityEngine;

public class OnTriggeredDamageArea : MonoBehaviour
{
    [SerializeField] private Projectile bullet;
    [SerializeField] private OverlapArea overlapArea;

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

    private void HandleTriggered(Collider2D other)
    {
        if (overlapArea != null)
        {
            Collider2D[] colliders = overlapArea.OverlapAll();

            foreach (Collider2D collider in colliders)
            {
                Life life = collider.GetComponentInChildren<Life>();

                if (life != null)
                {
                    life.TakeDamage(bullet.Damage);
                }
            }
        }
    }
}
