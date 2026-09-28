using UnityEngine;

public class AIPatrolBehaviour : AIBehaviour
{
    [SerializeField] private Follower follower;
    [SerializeField] private PathManager pathManager;
    [SerializeField] private float stopDistance = 0.1f;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Execute()
    {
        if (follower != null && pathManager != null && pathManager.Waypoints != null && pathManager.Waypoints.Length != 0)
        {
            Transform currentWaypoint = pathManager.Waypoints[pathManager.WaypointIndex];
            follower.Follow(currentWaypoint.position, stopDistance);
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
