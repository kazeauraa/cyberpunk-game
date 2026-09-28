using UnityEngine;

public class OnDiedState : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private CharacterStateManager characterStateManager;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += SetDeadState;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= SetDeadState;
        }
    }

    private void SetDeadState()
    {
        characterStateManager.CurrentState = CharacterState.Dead;
    }
}