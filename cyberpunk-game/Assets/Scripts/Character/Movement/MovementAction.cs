using System;
using UnityEngine;

public class MovementAction : MonoBehaviour
{
    public event Action OnUpdatedDirection;

    [SerializeField] private MovementBehaviour behaviourType;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float timeToReachMaxSpeed = 0.2f;
    [SerializeField] private float timeToReachNullSpeed = 0.15f;

    private IMovementBehaviour movementBehaviour;

    private float acceleration;
    private bool hasReachedNullSpeed;
    private float originalSpeed;
    private Vector2 direction;

    public float Speed
    {
        get => speed;
        set => speed = value < 0f ? 0f : value;
    }

    public bool Ignore { get; set; }

    public Vector2 Direction
    {
        get => direction;
        set
        {
            Vector2 normalized = value.normalized;
            if (normalized != Vector2.zero)
            {
                if (Mathf.Sign(normalized.x) != Mathf.Sign(LastDirection.x)
                    || Mathf.Sign(normalized.y) != Mathf.Sign(LastDirection.y))
                {
                    acceleration = 0f;
                }

                LastDirection = normalized;
                hasReachedNullSpeed = false;
                OnUpdatedDirection?.Invoke();
            }
            direction = normalized;
        }
    }

    public Vector2 LastDirection { get; private set; }

    private void Awake()
    {
        movementBehaviour = MovementBehaviourFactory.GenerateBehaviour(behaviourType);

        originalSpeed = speed;
        acceleration = 0f;
        hasReachedNullSpeed = false;
    }

    private void Update()
    {
        if (!Ignore)
        {
            HandleAcceleration();
        }
    }

    private void HandleAcceleration()
    {
        if (direction != Vector2.zero)
        {
            // Accelerate towards max speed
            if (acceleration < 1f)
            {
                if (timeToReachMaxSpeed > 0f)
                {
                    acceleration += Time.deltaTime / timeToReachMaxSpeed;
                    acceleration = Mathf.Clamp01(acceleration);
                }
                else
                {
                    acceleration = 1f;
                }
            }
        }
        else
        {
            // Decelerate towards null speed
            if (acceleration > 0f && !hasReachedNullSpeed)
            {
                if (timeToReachNullSpeed > 0f)
                {
                    acceleration -= Time.deltaTime / timeToReachNullSpeed;
                    acceleration = Mathf.Clamp01(acceleration);
                }
                else
                {
                    acceleration = 0f;
                }

                if (acceleration <= 0f)
                {
                    hasReachedNullSpeed = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Ignore)
        {
            if (!hasReachedNullSpeed)
            {
                movementBehaviour.Move(rb, speed * acceleration, LastDirection);
            }
            else
            {
                Stop();
            }
        }
    }

    public void ResetSpeed()
    {
        speed = originalSpeed;
    }

    public bool IsMoving()
    {
        return movementBehaviour.IsMoving(rb);
    }

    public void Stop()
    {
        movementBehaviour.Stop(rb);
    }
}