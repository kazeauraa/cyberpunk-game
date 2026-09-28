using System;
using UnityEngine;

public class FallAction : MonoBehaviour
{
    public event Action OnStartedFalling;
    public event Action OnStoppedFalling;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private OverlapArea overlapArea;
    [SerializeField, Min(-2f)] private float fallMultiplier = 3f;

    private Vector2 gravity;
    private bool falling = false;

    private void Awake()
    {
        gravity = new Vector2(0, -Physics2D.gravity.y);
    }

    private void Update()
    {
        bool isGrounded = overlapArea.OverlapOne();
        bool isFalling = rb.linearVelocity.y < 0f && !isGrounded;

        if (isFalling && !falling)
        {
            falling = true;
            OnStartedFalling?.Invoke();
        }
        else if (!isFalling && falling)
        {
            falling = false;
            OnStoppedFalling?.Invoke();
        }

        if (falling)
        {
            Fall();
        }
    }

    private void Fall()
    {
        rb.linearVelocity -= fallMultiplier * Time.deltaTime * gravity;
    }
}