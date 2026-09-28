using System;
using System.Collections;
using UnityEngine;

public class KnockbackHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public event Action OnKnockbackApplied;
    public event Action OnKnockbackStopped;

    private Coroutine knockbackCoroutine;

    public void Apply(Vector2 direction, float force, float duration, float decelerationSpeed)
    {
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on KnockbackHandler");
        }
        else
        {
            if (knockbackCoroutine == null)
            {
                OnKnockbackApplied?.Invoke();

                rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
                rb.AddForce(direction * force, ForceMode2D.Impulse);
                knockbackCoroutine = StartCoroutine(StopKnockback(duration, decelerationSpeed));
            }
        }
    }

    private IEnumerator StopKnockback(float duration, float decelerationSpeed)
    {
        yield return new WaitForSeconds(duration);

        while (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
        {
            float newX = Mathf.Lerp(rb.linearVelocity.x, 0f, Time.deltaTime * decelerationSpeed);
            rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y);
            yield return null;
        }

        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        OnKnockbackStopped?.Invoke();
        knockbackCoroutine = null;
    }
}