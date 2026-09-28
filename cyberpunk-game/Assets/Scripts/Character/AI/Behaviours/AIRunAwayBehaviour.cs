using UnityEngine;

public class AIRunAwayBehaviour : AIBehaviour
{
    [SerializeField] private MovementState movementState;
    [SerializeField] private TargetProvider targetProvider;

    public override void Execute()
    {
        if (movementState != null && targetProvider.Target != null)
        {
            Vector2 direction = (transform.position - targetProvider.Target.position).normalized;
            movementState.SetDirection(direction);
        }
    }

    public override void Stop()
    {
        if (movementState != null)
        {
            movementState.SetDirection(Vector2.zero);
        }
    }
}
