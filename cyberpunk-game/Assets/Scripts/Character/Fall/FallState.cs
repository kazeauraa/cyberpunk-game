using UnityEngine;

public class FallState : MonoBehaviour
{
    [SerializeField] private FallAction fallAction;
    [SerializeField] private CharacterStateManager stateManager;

    private void OnEnable()
    {
        if (fallAction != null)
        {
            fallAction.OnStartedFalling += SetFallingState;
            fallAction.OnStoppedFalling += SetNotFallingState;
        }
    }

    private void OnDisable()
    {
        if (fallAction != null)
        {
            fallAction.OnStartedFalling -= SetFallingState;
            fallAction.OnStoppedFalling -= SetNotFallingState;
        }

        if (stateManager.CurrentState == CharacterState.Falling)
        {
            stateManager.CurrentState = CharacterState.Normal;
        }
    }

    private void SetFallingState()
    {
        if (stateManager.CurrentState != CharacterState.Dead)
        {
            stateManager.CurrentState = CharacterState.Falling;
        }
    }

    private void SetNotFallingState()
    {
        if (stateManager.CurrentState == CharacterState.Falling)
        {
            stateManager.CurrentState = CharacterState.Normal;
        }
    }
}