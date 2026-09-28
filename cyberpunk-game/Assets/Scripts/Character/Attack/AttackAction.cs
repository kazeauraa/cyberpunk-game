using System;
using System.Collections;
using UnityEngine;

public abstract class AttackAction : MonoBehaviour
{
    public event Action OnAttackStarted;
    public event Action OnAttackFinished;

    private bool attacking;

    public abstract AttackData AttackData { get; }

    public bool TryAttack()
    {
        bool canAttack = !attacking;

        if (canAttack)
        {
            attacking = true;
            StartCoroutine(ExecuteAttackActionDelay());
            StartCoroutine(AttackCooldown());

            OnAttackStarted?.Invoke();
        }

        return canAttack;
    }

    private IEnumerator ExecuteAttackActionDelay()
    {
        yield return new WaitForSeconds(AttackData.ActionExecutionTime);
        ExecuteAttackAction();
    }

    protected abstract void ExecuteAttackAction();

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(AttackData.Cooldown);
        attacking = false;
        OnAttackFinished?.Invoke();
    }
}