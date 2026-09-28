using UnityEngine;

public class OnDiedAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Life life;
    [SerializeField] private string animationTag;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += PlayAnimation;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= PlayAnimation;
        }
    }

    private void PlayAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(animationTag);
        }
    }
}