using UnityEngine;

public class KnockbackMovementMediator : MonoBehaviour
{
    [SerializeField] private KnockbackHandler knockbackHandler;
    [SerializeField] private MovementAction movementAction;

    private void Start()
    {
        if (knockbackHandler != null)
        {
            knockbackHandler.OnKnockbackApplied += HandleKnockbackApplied;
            knockbackHandler.OnKnockbackStopped += HandleKnockbackStopped;
        }
    }

    private void OnDestroy()
    {
        if (knockbackHandler != null)
        {
            knockbackHandler.OnKnockbackApplied -= HandleKnockbackApplied;
            knockbackHandler.OnKnockbackStopped -= HandleKnockbackStopped;
        }
    }

    private void HandleKnockbackApplied()
    {
        if (movementAction != null)
        {
            movementAction.Ignore = true;
        }
    }

    private void HandleKnockbackStopped()
    {
        if (movementAction != null)
        {
            movementAction.Ignore = false;
        }
    }
}