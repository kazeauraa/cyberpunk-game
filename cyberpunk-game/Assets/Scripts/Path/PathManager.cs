using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waypointReachRange = 0.25f;

    private int waypointIndex;
    private int direction = 1;

    public Transform[] Waypoints
    {
        get => waypoints;
        set => waypoints = value;
    }

    public int WaypointIndex => waypointIndex;

    public bool ReachedEnd => waypointIndex == waypoints.Length - 1
        && Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= waypointReachRange;

    private void Awake()
    {
        foreach (var waypoint in waypoints)
        {
            waypoint.SetParent(null);
        }
    }

    void Update()
    {
        HandleWaypoint();
    }

    private void HandleWaypoint()
    {
        if (waypoints != null && waypoints.Length != 0)
        {
            float distance = Vector2.Distance(transform.position, waypoints[waypointIndex].position);

            if (distance <= waypointReachRange)
            {
                int next = waypointIndex + direction;

                if (next >= waypoints.Length)
                {
                    direction = -1;
                    next = waypointIndex + direction;
                }
                else if (next < 0)
                {
                    direction = 1;
                    next = waypointIndex + direction;
                }

                waypointIndex = next;
            }
        }
    }
}
