using UnityEngine;

public class TargetRotator : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float offset;
    [SerializeField] private RangeDetector rangeDetector;

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
        if (target != null && rangeDetector.Detected)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        }
    }
}
