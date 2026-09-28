using UnityEngine;

public class OnDiedDestroy : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private GameObject master;
    [SerializeField] private float delay;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += DestroySelf;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= DestroySelf;
        }
    }

    private void DestroySelf()
    {
        Destroy(master, delay);
    }
}