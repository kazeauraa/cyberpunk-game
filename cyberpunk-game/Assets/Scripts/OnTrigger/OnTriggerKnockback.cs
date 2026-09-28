using UnityEngine;

public class OnTriggerKnockback : MonoBehaviour
{
    [SerializeField] private float force = 15f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
