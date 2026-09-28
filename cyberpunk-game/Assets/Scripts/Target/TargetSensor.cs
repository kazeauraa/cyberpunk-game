using UnityEngine;

public class TargetSensor : MonoBehaviour
{
    [SerializeField] private OverlapArea overlapArea;
    [SerializeField] private float updateTime;

    public Transform Target { get; private set; }

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateTime)
        {
            timer = 0f;
            DetectNewTarget();
        }
    }

    private void DetectNewTarget()
    {
        Collider2D[] colliders = overlapArea.OverlapAll();

        if (colliders.Length > 0)
        {
            Transform nearest = null;
            float minDistance = float.MaxValue;

            foreach (Collider2D collider in colliders)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;

                    TargetValidator validator = collider.GetComponentInChildren<TargetValidator>();
                    if (validator == null || validator.Valid)
                    {
                        nearest = collider.transform;
                    }

                }
            }

            Target = nearest;
        }
    }
}