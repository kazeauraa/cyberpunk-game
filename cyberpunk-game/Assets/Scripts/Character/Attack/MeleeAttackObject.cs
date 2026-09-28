using UnityEngine;

[CreateAssetMenu(fileName = "NewMeleeAttack", menuName = "Scriptable Objects/Attacks/Melee")]
public class MeleeAttackObject : ScriptableObject
{
    [SerializeField] private AttackData data;
    [SerializeField, Min(1)] private int combos = 1;
    [SerializeField, Min(0.1f)] private float comboCooldown = 0.35f;
    [SerializeField] private DamageEffectObject[] damageEffects;

    public AttackData Data => data;
    public int Combos => combos;
    public float ComboCooldown => comboCooldown;

    public void ApplyEffects(GameObject sender, GameObject receiver)
    {
        foreach (DamageEffectObject effect in damageEffects)
        {
            if (effect != null)
            {
                effect.ApplyEffect(sender, receiver);
            }
        }
    }
}