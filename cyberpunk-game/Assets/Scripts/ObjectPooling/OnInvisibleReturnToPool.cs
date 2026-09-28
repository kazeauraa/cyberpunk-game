using UnityEngine;

public class OnInvisibleReturnToPool : MonoBehaviour
{
    [SerializeField] private PoolGO poolGO;

    private bool wasVisible;

    private void OnBecameVisible()
    {
        wasVisible = true;
    }

    private void OnBecameInvisible()
    {
        if (wasVisible)
        {
            wasVisible = false;
            poolGO.ReturnToPool();
        }
    }
}
