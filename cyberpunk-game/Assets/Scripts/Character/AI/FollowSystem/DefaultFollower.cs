using UnityEngine;

public class DefaultFollower : Follower
{
    [SerializeField] private MovementState movementState;

    public override void Follow(Vector2 newTargetPosition, float stopDistance)
    {
        Vector2 finalDirection = Vector2.zero;
        if (Vector2.Distance(transform.position, newTargetPosition) > stopDistance)
        {
            finalDirection = (newTargetPosition - (Vector2)transform.position).normalized;
        }

        movementState.SetDirection(finalDirection);
    }

    public override void StopFollow()
    {
        movementState.SetDirection(Vector2.zero);
    }
}