using UnityEngine;

public class FallAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private FallAction fall;
    [SerializeField] private string animationTag;

    private void OnEnable()
    {
        if (fall != null)
        {
            fall.OnStartedFalling += SetFallingTrue;
            fall.OnStoppedFalling += SetFallingFalse;
        }
    }

    private void OnDisable()
    {
        if (fall != null)
        {
            fall.OnStartedFalling -= SetFallingTrue;
            fall.OnStoppedFalling -= SetFallingFalse;
        }
    }

    private void SetFallingTrue()
    {
        animator.SetBool(animationTag, true);
    }

    private void SetFallingFalse()
    {
        animator.SetBool(animationTag, false);
    }
}