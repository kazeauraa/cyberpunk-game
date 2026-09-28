using UnityEngine;

public class VisibilityUpdater : MonoBehaviour
{
    public event System.Action OnVisible;
    public event System.Action OnInvisible;

    private void OnEnable()
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if(viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
        {
            OnVisible?.Invoke();
        }
        else
        {
            OnInvisible?.Invoke();
        }
    }

    private void OnBecameVisible()
    {
        OnVisible?.Invoke();
    }

    private void OnBecameInvisible()
    {
        OnInvisible?.Invoke();
    }
}
