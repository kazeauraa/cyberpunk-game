using UnityEngine;

public class OnDiedReturnToPool : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private PoolGO poolGO;
    [SerializeField] private float delay;

    private void Awake()
    {
        if (poolGO == null)
        {
            Debug.LogError("PoolGO component is not assigned in OnDiedReturnToPool script on " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += ReturnToPool;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedReturnToPool script on " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= ReturnToPool;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedReturnToPool script on " + gameObject.name);
        }
    }

    private void ReturnToPool()
    {
        if (delay > 0)
        {
            Invoke(nameof(ExecuteReturn), delay);
        }
        else
        {
            ExecuteReturn();
        }
    }

    private void ExecuteReturn()
    {
        poolGO.ReturnToPool();
    }
}