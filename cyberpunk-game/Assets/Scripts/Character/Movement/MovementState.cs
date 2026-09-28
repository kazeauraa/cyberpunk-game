using UnityEngine;

public class MovementState : StateBehaviour
{
    [SerializeField] private MovementAction action;

    private bool tried;
    private Vector2 triedDirection;

    private void Update()
    {
        if (tried && stateManager.IsStateIn(allowedStates))
        {
            tried = false;
            action.Direction = triedDirection;
        }
    }

    public void SetDirection(Vector2 direction)
    {
        if (stateManager.IsStateIn(allowedStates))
        {
            action.Direction = direction;
        }
        else
        {
            triedDirection = direction;
            tried = true;
        }
    }

    protected override void OnStateStart()
    {
        action.Ignore = false;
    }

    protected override void OnStateUpdate()
    {
    }

    protected override void OnStateEnd()
    {
        action.Ignore = true;
        action.Stop();
    }
}