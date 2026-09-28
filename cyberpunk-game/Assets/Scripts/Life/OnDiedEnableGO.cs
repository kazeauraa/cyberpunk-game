using UnityEngine;

public class OnDiedEnableGO : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private GameObject obj;

    private void Awake()
    {
        if (life == null)
        {
            life = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Life>();
        }

        if (life == null)
        {
            Debug.LogError("Life component not found!", this);
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
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }
}