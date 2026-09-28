using UnityEngine;

public abstract class TargetProvider : MonoBehaviour
{
    public abstract Transform Target { get; }

    public float Distance
    {
        get
        {
            float distance = 0f;

            if (Target != null)
            {
                distance = Vector2.Distance(transform.position, Target.position);
            }

            return distance;
        }
    }

    public Vector2 Direction
    {
        get
        {
            Vector2 direction = Vector2.zero;

            if (Target != null)
            {
                Vector2 currentPosition = transform.position;
                Vector2 targetPosition = Target.position;
                direction = (targetPosition - currentPosition).normalized;
            }

            return direction;
        }
    }
}