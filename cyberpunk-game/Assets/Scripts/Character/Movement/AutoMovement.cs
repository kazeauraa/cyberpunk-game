using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private MovementState movementState;
    [SerializeField] private Vector2 startDirection = Vector2.right;

    private void Start()
    {
        StartMovement(startDirection);
    }

    public void StartMovement(Vector2 direction)
    {
        movementState.SetDirection(direction);
    }
}
