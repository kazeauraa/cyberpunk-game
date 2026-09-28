using UnityEngine;

public class OnInvisibleDamage : MonoBehaviour
{
    [SerializeField] private VisibilityUpdater visibilityUpdater;
    [SerializeField] private Life life;
    [SerializeField] private int damage = 1;

    private void Awake()
    {
        if (visibilityUpdater == null)
        {
            Debug.LogError("VisibilityUpdater not assigned!", this);
        }

        if (life == null)
        {
            Debug.LogError("Life object not assigned!", this);
        }
    }

    private void OnEnable()
    {
        if (visibilityUpdater != null)
        {
            visibilityUpdater.OnInvisible += HandleOnInvisible;
        }
    }

    private void OnDisable()
    {
        if (visibilityUpdater != null)
        {
            visibilityUpdater.OnInvisible -= HandleOnInvisible;
        }
    }

    private void HandleOnInvisible()
    {
        life.TakeDamage(damage);
    }
}