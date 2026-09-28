using UnityEngine;

public class MeleeAttackAction : AttackAction
{
    [SerializeField] private MeleeAttackObject attack;
    [SerializeField] private OverlapArea attackArea;

    public override AttackData AttackData => attack.Data;

    public int Combos => attack.Combos;
    public float ComboCooldown => attack.ComboCooldown;

    protected override void ExecuteAttackAction()
    {
        Collider2D[] hitColliders = attackArea.OverlapAll();

        foreach (Collider2D hitCollider in hitColliders)
        {
            IDamageable damageable = hitCollider.GetComponentInChildren<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(AttackData.Damage);
            }

            attack.ApplyEffects(gameObject, hitCollider.gameObject);
        }
    }
}