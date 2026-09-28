using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AttackAction attackAction;
    [SerializeField] private string animationTag;

    private void OnEnable()
    {
        if (attackAction != null)
        {
            attackAction.OnAttackStarted += PlayAnimation;
        }
    }

    private void OnDisable()
    {
        if (attackAction != null)
        {
            attackAction.OnAttackStarted -= PlayAnimation;
        }
    }

    private void PlayAnimation()
    {
        animator.SetTrigger(animationTag);
    }
}