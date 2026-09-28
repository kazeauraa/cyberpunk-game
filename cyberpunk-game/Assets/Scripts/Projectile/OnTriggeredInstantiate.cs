using UnityEngine;

public class OnTriggeredInstantiate : MonoBehaviour
{
    [SerializeField] private Projectile bullet;
    [SerializeField] private GameObject prefab;

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
        if (prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
