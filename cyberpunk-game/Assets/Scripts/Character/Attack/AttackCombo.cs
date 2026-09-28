using UnityEngine;

public class AttackCombo : MonoBehaviour
{
    public event System.Action<int> OnComboAttack;

    [SerializeField] private MeleeAttackAction attackAction;
    [SerializeField] private Animator animator;
    [SerializeField] private string animationTag = "AttackCombo";

    private int currentComboIndex = 0;
    private float lastAttackTime = 0f;

    private void Awake()
    {
        if (attackAction == null)
        {
            Debug.LogError("OnAttackComboAnimation: MeleeAttackAction reference is missing.", this);
        }

        if (animator == null)
        {
            Debug.LogError("OnAttackComboAnimation: Animator reference is missing.", this);
        }
    }

    private void OnEnable()
    {
        attackAction.OnAttackStarted += HandleAttack;
    }

    private void OnDisable()
    {
        attackAction.OnAttackStarted -= HandleAttack;
    }

    private void HandleAttack()
    {
        // Check if too much time has passed since last attack
        if (Time.time > lastAttackTime + attackAction.ComboCooldown)
        {
            // Reset combo
            currentComboIndex = 0;
        }

        animator.SetInteger(animationTag, currentComboIndex);
        OnComboAttack?.Invoke(currentComboIndex);

        // Update combo state
        currentComboIndex = (currentComboIndex + 1) % attackAction.Combos;
        lastAttackTime = Time.time;
    }
}
