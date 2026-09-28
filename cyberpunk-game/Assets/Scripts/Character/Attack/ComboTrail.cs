using UnityEngine;

public class ComboTrail : MonoBehaviour
{
    [SerializeField] private AttackCombo attackCombo;
    [SerializeField] private int combo;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private float emitDuration = 0.5f;

    private void OnEnable()
    {
        attackCombo.OnComboAttack += HandleComboAttack;
    }

    private void OnDisable()
    {
        attackCombo.OnComboAttack -= HandleComboAttack;
    }

    private void HandleComboAttack(int currentCombo)
    {
        if (currentCombo == combo)
        {
            Emit();
        }
    }

    private void Emit()
    {
        trail.Clear();
        trail.emitting = true;

        Invoke(nameof(Unemit), emitDuration);
    }

    private void Unemit()
    {
        trail.emitting = false;
    }
}
