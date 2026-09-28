using UnityEngine;

public class OnDiedChangeRigidbodyState : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RigidbodyType2D rigidbodyType;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += OnDied;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedChangeRigidbodyState script on " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= OnDied;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedChangeRigidbodyState script on " + gameObject.name);
        }
    }

    private void OnDied()
    {
        if (rb != null)
        {
            rb.bodyType = rigidbodyType;
        }
        else
        {
            Debug.LogError("Rigidbody2D is not assigned in OnDiedChangeRigidbodyState script on " + gameObject.name);
        }
    }
}