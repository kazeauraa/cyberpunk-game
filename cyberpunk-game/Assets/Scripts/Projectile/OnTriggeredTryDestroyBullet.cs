using System;
using System.Linq;
using UnityEngine;

public class OnTriggeredTryDestroyBullet : MonoBehaviour
{
    [SerializeField] private Projectile bullet;
    [SerializeField] private PoolGO poolGO;
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

    private void HandleTriggered(Collider2D other)
    {
        if (triggerTags.Contains(other.tag))
        {
            bullet.Pierce--;

            if (bullet.Pierce <= 0)
            {
                poolGO.ReturnToPool();
            }
        }
    }
}