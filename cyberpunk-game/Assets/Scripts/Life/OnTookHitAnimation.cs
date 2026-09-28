using UnityEngine;

public class OnTookHitAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Life life;
    [SerializeField] private string animationTag;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnTookHit += PlayAnimation;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnTookHit -= PlayAnimation;
        }
    }

    private void PlayAnimation(int damage)
    {
        if (animator != null)
        {
            animator.SetTrigger(animationTag);
        }
    }
}