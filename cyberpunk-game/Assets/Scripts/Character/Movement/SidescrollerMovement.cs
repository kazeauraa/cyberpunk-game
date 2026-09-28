using UnityEngine;

public class SidescrollerMovement : IMovementBehaviour
{
    public void Move(Rigidbody2D rb, float speed, Vector2 direction)
    {
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
    }

    public void Stop(Rigidbody2D rb)
    {
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
    }

    public bool IsMoving(Rigidbody2D rb)
    {
        return Mathf.Abs(rb.linearVelocity.x) > 0.1f;
    }
}