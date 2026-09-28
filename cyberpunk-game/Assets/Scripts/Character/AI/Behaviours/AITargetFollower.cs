using UnityEngine;

public class AITargetFollower : AIBehaviour
{
    [SerializeField] private Follower follower;
    [SerializeField] private TargetProvider targetProvider;
    [SerializeField] private TargetContext targetContext;
    [SerializeField] private float stopDistance = 2f;

    public override void Initialize()
    {
        base.Initialize();
        targetContext.Target = targetProvider.Target;
    }

    public override void Execute()
    {
        if (follower != null && targetProvider.Target != null)
        {
            follower.Follow(targetProvider.Target.position, stopDistance);
        }
    }

    public override void Stop()
    {
        if (follower != null)
        {
            follower.StopFollow();
        }
    }
}