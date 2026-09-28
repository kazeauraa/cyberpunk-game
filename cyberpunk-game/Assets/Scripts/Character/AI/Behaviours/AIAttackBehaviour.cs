using UnityEngine;

public class AIAttackBehaviour : AIBehaviour
{
    [SerializeField] private AttackState attackState;
    [SerializeField] private Flip flip;
    [SerializeField] private TargetProvider targetProvider;
    [SerializeField] private TargetContext targetContext;
    [SerializeField] private float delay = 0.5f;

    private float lastAttackTime;

    public override void Initialize()
    {
        base.Initialize();

        lastAttackTime = Time.time;
        targetContext.Target = targetProvider.Target;
    }

    public override void Execute()
    {
        if (attackState != null && targetProvider.Target != null)
        {
            Vector2 targetPosition = targetProvider.Target.transform.position;
            if (Time.time - lastAttackTime >= delay)
            {
                if (attackState.TryAttack())
                {
                    flip.FlipTowards(transform.position.x < targetPosition.x ? 1 : -1);
                }
                lastAttackTime = Time.time;
            }
        }
    }
}