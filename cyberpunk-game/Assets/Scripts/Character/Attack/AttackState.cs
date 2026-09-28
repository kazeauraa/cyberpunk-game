using UnityEngine;

public class AttackState : StateBehaviour
{
    [SerializeField] private AttackAction action;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (action != null)
        {
            action.OnAttackFinished += OnAttackFinished;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (action != null)
        {
            action.OnAttackFinished -= OnAttackFinished;
        }
    }

    public bool TryAttack()
    {
        bool canAttack = false;

        if (stateManager.IsStateIn(allowedStates))
        {
            canAttack = action.TryAttack();

            if (canAttack)
            {
                stateManager.CurrentState = CharacterState.Attacking;
            }
        }

        return canAttack;
    }

    private void OnAttackFinished()
    {
        if (stateManager.CurrentState == CharacterState.Attacking)
        {
            stateManager.CurrentState = CharacterState.Normal;
        }
    }

    protected override void OnStateStart()
    {
    }

    protected override void OnStateUpdate()
    {
    }

    protected override void OnStateEnd()
    {
    }
}