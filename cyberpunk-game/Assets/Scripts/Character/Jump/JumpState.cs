using UnityEngine;

public class JumpState : StateBehaviour
{
    [SerializeField] private JumpAction action;

    protected override void OnDisable()
    {
        base.OnDisable();

        if (stateManager.CurrentState == CharacterState.Jumping && !action.IsJumping)
        {
            stateManager.CurrentState = CharacterState.Normal;
        }
    }

    public bool TryJump()
    {
        bool canJump = false;

        if (stateManager.IsStateIn(allowedStates))
        {
            canJump = action.Jump();

            if (canJump)
            {
                stateManager.CurrentState = CharacterState.Jumping;
            }
        }

        return canJump;
    }

    public void ExtendJump()
    {
        action.ExtendJump();
    }

    protected override void OnStateStart()
    {
    }

    protected override void OnStateUpdate()
    {
        if (stateManager.CurrentState == CharacterState.Jumping && !action.IsJumping)
        {
            stateManager.CurrentState = CharacterState.Normal;
        }
    }

    protected override void OnStateEnd()
    {
    }
}