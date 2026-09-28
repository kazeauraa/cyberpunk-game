using UnityEngine;

public abstract class StateBehaviour : MonoBehaviour
{
    [SerializeField] protected CharacterStateManager stateManager;
    [SerializeField] protected CharacterState[] allowedStates;

    private bool wasInAllowedState = false;

    protected virtual void OnEnable()
    {
        if (stateManager != null)
        {
            stateManager.OnStateUpdated += OnStateUpdated;
        }
    }

    protected virtual void OnDisable()
    {
        if (stateManager != null)
        {
            stateManager.OnStateUpdated -= OnStateUpdated;
        }
    }

    private void Update()
    {
        if (wasInAllowedState)
        {
            OnStateUpdate();
        }
    }

    private void OnStateUpdated()
    {
        bool isInAllowedState = stateManager.IsStateIn(allowedStates);

        if (isInAllowedState && !wasInAllowedState)
        {
            OnStateStart();
            wasInAllowedState = true;
        }
        else if (!isInAllowedState && wasInAllowedState)
        {
            OnStateEnd();
            wasInAllowedState = false;
        }
    }

    protected abstract void OnStateStart();
    protected abstract void OnStateUpdate();
    protected abstract void OnStateEnd();
}