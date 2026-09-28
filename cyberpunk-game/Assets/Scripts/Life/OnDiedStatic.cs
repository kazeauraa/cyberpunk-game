using UnityEngine;

public class OnDiedStatic : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private Rigidbody2D rb;

    private void OnEnable()
    {
        life.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        life.OnDied -= HandleDied;
    }

    private void HandleDied()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
}
