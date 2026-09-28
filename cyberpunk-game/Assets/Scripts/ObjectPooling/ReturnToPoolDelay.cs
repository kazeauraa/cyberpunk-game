using UnityEngine;

public class ReturnToPoolDelay : MonoBehaviour
{
    [SerializeField] private PoolGO poolGO;
    [SerializeField] private float delay;

    private float timer;

    private void Awake()
    {
        if (poolGO == null)
        {
            Debug.LogError("PoolGO is not assigned in ReturnToPoolDelay");
        }
    }

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            poolGO.ReturnToPool();
        }
    }
}