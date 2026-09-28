using UnityEngine;

public interface IMovementBehaviour
{
    void Move(Rigidbody2D rb, float speed, Vector2 direction);
    void Stop(Rigidbody2D rb);
    bool IsMoving(Rigidbody2D rb);
}