using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathManager pathManager;
    [SerializeField] private float speed = 3f;

    private void Update()
    {
        if (pathManager != null && pathManager.Waypoints != null && pathManager.Waypoints.Length != 0)
        {
            Transform target = pathManager.Waypoints[pathManager.WaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
