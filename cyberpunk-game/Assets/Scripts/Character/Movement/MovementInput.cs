using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInput : Input
{
    [SerializeField] private MovementState movementState;

    public override void Enable()
    {
        inputActions.Player.Move.performed += Execute;
        inputActions.Player.Move.canceled += Execute;
        inputActions.Player.Enable();
    }

    public override void Disable()
    {
        inputActions.Player.Move.performed -= Execute;
        inputActions.Player.Move.canceled -= Execute;
        inputActions.Player.Disable();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        Vector2 direction = new Vector2(input, 0f);

        movementState.SetDirection(direction);
    }
}