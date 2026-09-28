using UnityEngine;
using UnityEngine.InputSystem;

public class JumpInput : Input
{
    [SerializeField] private JumpState jumpState;
    [SerializeField] private float bufferTime = 0.1f;

    private float bufferTimer;
    private bool bufferPending;
    private bool isHolding;

    public override void Enable()
    {
        inputActions.Player.Jump.performed += Execute;
        inputActions.Player.Jump.canceled += OnJumpCanceled;
        inputActions.Player.Enable();
    }

    public override void Disable()
    {
        inputActions.Player.Jump.performed -= Execute;
        inputActions.Player.Jump.canceled -= OnJumpCanceled;
        inputActions.Player.Disable();

        // Clear any pending buffered input when disabling
        bufferPending = false;
        bufferTimer = 0f;
        isHolding = false;
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        // If the jump failed, schedule a single retry after bufferTime
        if (!jumpState.TryJump())
        {
            bufferPending = true;
            bufferTimer = bufferTime;
        }
        else
        {
            isHolding = true;
        }
    }

    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        isHolding = false;
    }

    private void Update()
    {
        if (bufferPending)
        {
            bufferTimer -= Time.deltaTime;

            if (bufferTimer <= 0f)
            {
                bufferPending = false;
                jumpState.TryJump();
            }
        }

        // Extend the current jump without starting a new one
        if (isHolding)
        {
            jumpState.ExtendJump();
        }
    }
}