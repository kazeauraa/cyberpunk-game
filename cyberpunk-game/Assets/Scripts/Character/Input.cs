using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Input : MonoBehaviour
{
    protected PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    protected virtual void OnEnable()
    {
        Enable();
    }

    protected virtual void OnDisable()
    {
        Disable();
    }

    public abstract void Enable();
    public abstract void Disable();
    public abstract void Execute(InputAction.CallbackContext context);
}