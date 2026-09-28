using UnityEngine;

public class TopDownMovement : IMovementBehaviour
{
    public void Move(Rigidbody2D rb, float speed, Vector2 direction)
    {
        rb.linearVelocity = direction * speed;
    }

    public void Stop(Rigidbody2D rb)
    {
        rb.linearVelocity = Vector2.zero;
    }

    public bool IsMoving(Rigidbody2D rb)
    {
        return Mathf.Sqrt(rb.linearVelocity.sqrMagnitude) > 0.1f;
    }
}