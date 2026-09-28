using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackInput : Input
{
    public event Action OnHoldReached;

    [SerializeField] private AttackState attackState;
    [SerializeField] private InputActionReference reference;

    [Header("Press")]
    [SerializeField] private float maxHoldTime = 0.1f;

    [Header("Hold")]
    [SerializeField] private bool requiresHoldRelease = false;

    private float pressTime;
    private bool holdReached;

    public override void Enable()
    {
        reference.action.started += OnStarted;
        reference.action.performed += OnPerformed;
        reference.action.canceled += OnCanceled;
        reference.action.Enable();
    }

    public override void Disable()
    {
        reference.action.started -= OnStarted;
        reference.action.performed -= OnPerformed;
        reference.action.canceled -= OnCanceled;
        reference.action.Disable();
    }

    private void OnStarted(InputAction.CallbackContext context)
    {
        pressTime = Time.time;
        holdReached = false;
    }

    private void OnPerformed(InputAction.CallbackContext context)
    {
        if (requiresHoldRelease)
        {
            holdReached = true;
            OnHoldReached?.Invoke();
        }
    }

    private void OnCanceled(InputAction.CallbackContext context)
    {
        float heldTime = Time.time - pressTime;

        if (requiresHoldRelease)
        {
            if (holdReached)
            {
                attackState.TryAttack();
            }
        }
        else if (heldTime <= maxHoldTime)
        {
            attackState.TryAttack();
        }
    }

    public override void Execute(InputAction.CallbackContext context)
    {
    }
}