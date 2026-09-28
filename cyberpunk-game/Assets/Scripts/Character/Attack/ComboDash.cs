using UnityEngine;

public class ComboDash : MonoBehaviour
{
    [SerializeField] private AttackCombo attackCombo;
    [SerializeField] private int combo;
    [SerializeField] private Transform master;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private MovementAction movementAction;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float dashTime = 0.2f;

    private bool dashing;
    private float dashTimer;
    private Vector2 dashDirection;

    private void OnEnable()
    {
        attackCombo.OnComboAttack += HandleComboAttack;
    }

    private void OnDisable()
    {
        attackCombo.OnComboAttack -= HandleComboAttack;
    }

    private void Update()
    {
        if (dashing)
        {
            dashTimer -= Time.deltaTime;
            movementAction.Ignore = true;

            if (dashTimer <= 0f)
            {
                StopDash();
            }
        }
    }

    private void FixedUpdate()
    {
        if (dashing)
        {
            rb.linearVelocity = dashDirection * speed;
        }
    }

    private void HandleComboAttack(int currentCombo)
    {
        if (currentCombo == combo)
        {
            dashDirection = master.localScale.x >= 0f ? Vector2.right : Vector2.left;
            dashTimer = dashTime;
            dashing = true;
        }
    }

    private void StopDash()
    {
        dashing = false;
        movementAction.Ignore = false;
        rb.linearVelocity = Vector2.zero;
    }
}