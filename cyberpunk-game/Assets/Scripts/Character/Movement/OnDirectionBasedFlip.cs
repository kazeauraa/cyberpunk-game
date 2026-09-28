using UnityEngine;

public class OnDirectionBasedFlip : MonoBehaviour
{
    [SerializeField] private MovementAction movement;
    [SerializeField] private Flip flip;

    private void OnEnable()
    {
        if (movement != null)
        {
            movement.OnUpdatedDirection += HandleDirectionUpdated;
        }
    }

    private void OnDisable()
    {
        if (movement != null)
        {
            movement.OnUpdatedDirection -= HandleDirectionUpdated;
        }
    }

    private void HandleDirectionUpdated()
    {
        flip.FlipTowards(movement.LastDirection.x);
    }
}