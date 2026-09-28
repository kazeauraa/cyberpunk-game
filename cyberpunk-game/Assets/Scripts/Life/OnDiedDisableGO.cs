using UnityEngine;

public class OnDiedDisableGO : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private GameObject obj;

    private void Awake()
    {
        if (life == null)
        {
            Debug.LogError("Life not assigned!", this);
        }
    }

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += HandleOnDied;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= HandleOnDied;
        }
    }

    private void HandleOnDied()
    {
        obj.SetActive(false);
    }
}