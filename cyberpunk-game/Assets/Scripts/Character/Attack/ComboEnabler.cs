using UnityEngine;

public class ComboEnabler : MonoBehaviour
{
    [SerializeField] private AttackCombo attackCombo;
    [SerializeField] private int combo = 0;
    [SerializeField] private GameObject target;
    [SerializeField] private float duration = 0.25f;

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
            target.SetActive(true);
            Invoke(nameof(DisableTarget), duration);
        }
    }

    private void DisableTarget()
    {
        target.SetActive(false);
    }
}