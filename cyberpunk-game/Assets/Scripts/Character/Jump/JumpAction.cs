using System;
using UnityEngine;

public class JumpAction : MonoBehaviour
{
    public event Action OnStartedJump;
    public event Action OnStoppedJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private OverlapArea groundCheck;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private float jumpTime = 0.2f;
    [SerializeField] private int jumps = 1;
    [SerializeField] private float coyoteTime = 0.2f;

    public bool IsJumping { get; private set; }
    public bool FirstJump { get; private set; }

    private int remainingJumps;
    private float coyoteTimer;
    private float jumpTimer;
    private bool wasGrounded;

    private void Update()
    {
        if (rb.linearVelocity.y <= 2 && groundCheck.OverlapOne())
        {
            if (IsJumping)
            {
                OnStoppedJump?.Invoke();
            }

            IsJumping = false;
            jumpTimer = 0f;
            remainingJumps = jumps;
            FirstJump = true;
        }

        HandleCoyoteTimer();
    }

    private void HandleCoyoteTimer()
    {
        bool isGrounded = groundCheck.OverlapOne();

        if (isGrounded)
        {
            coyoteTimer = coyoteTime;
            wasGrounded = true;
        }
        else if (wasGrounded)
        {
            coyoteTimer -= Time.deltaTime;

            if (coyoteTimer <= 0f)
            {
                wasGrounded = false;
            }
        }
    }

    public bool Jump()
    {
        bool canJump = false;

        // Start a new jump
        if ((coyoteTimer > 0 && remainingJumps > 0) || remainingJumps > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            remainingJumps--;
            coyoteTimer = 0f;
            jumpTimer = jumpTime;
            IsJumping = true;
            canJump = true;

            OnStartedJump?.Invoke();

            FirstJump = false;
        }

        return canJump;
    }

    public void ExtendJump()
    {
        // Only extend an already active jump, never start a new one
        if (IsJumping && jumpTimer > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpTimer -= Time.deltaTime;
        }
    }
}