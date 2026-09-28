using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MovementAction movement;
    [SerializeField] private string animationTag;

    private void Update()
    {
        animator.SetBool(animationTag, movement.IsMoving());
    }
}