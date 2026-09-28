using UnityEngine;

public class OnTookHitState : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private CharacterStateManager characterStateManager;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnTookHit += SetTakingHitState;
            life.OnTookHitOver += SetNormalState;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnTookHit -= SetTakingHitState;
            life.OnTookHitOver -= SetNormalState;
        }
    }

    private void SetTakingHitState(int damage)
    {
        characterStateManager.CurrentState = CharacterState.TakingHit;
    }

    private void SetNormalState()
    {
        characterStateManager.CurrentState = CharacterState.Normal;
    }
}