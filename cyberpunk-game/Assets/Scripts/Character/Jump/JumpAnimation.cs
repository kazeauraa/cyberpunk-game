using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private JumpAction jump;
    [SerializeField] private string animationTag;

    private void OnEnable()
    {
        if (jump != null)
        {
            jump.OnStartedJump += SetJumpingTrue;
            jump.OnStoppedJump += SetJumpingFalse;
        }
    }

    private void OnDisable()
    {
        if (jump != null)
        {
            jump.OnStartedJump -= SetJumpingTrue;
            jump.OnStoppedJump -= SetJumpingFalse;
        }
    }

    private void SetJumpingTrue()
    {
        animator.SetBool(animationTag, true);
    }

    private void SetJumpingFalse()
    {
        animator.SetBool(animationTag, false);
    }
}