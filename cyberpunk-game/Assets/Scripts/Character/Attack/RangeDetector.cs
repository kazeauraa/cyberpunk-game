using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float maxDistance = 10f;

    public bool Detected { get; private set; }

    private Transform target;

    private void Start()
    {
        GameObject targetObj = GameObject.FindWithTag(targetTag);

        if (targetObj != null)
        {
            target = targetObj.transform;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            Detected = false;
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;

        LayerMask combinedMask = targetLayer | wallLayer;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, combinedMask);

        Detected = hit.collider != null && ((1 << hit.collider.gameObject.layer) & targetLayer) != 0;
    }

    private void OnDrawGizmos()
    {
        if (target == null) return;

        Gizmos.color = Detected ? Color.green : Color.red;

        Vector2 direction = (target.position - transform.position).normalized;
        LayerMask combinedMask = targetLayer | wallLayer;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, combinedMask);

        Vector3 endPoint = hit.collider != null
            ? (Vector3)hit.point
            : transform.position + (Vector3)direction * maxDistance;

        Gizmos.DrawLine(transform.position, endPoint);
    }
}
