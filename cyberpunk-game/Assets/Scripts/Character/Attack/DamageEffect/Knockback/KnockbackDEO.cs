using UnityEngine;

[CreateAssetMenu(fileName = "New Knockback Effect", menuName = "Scriptable Objects/Damage Effects/Knockback")]
public class KnockbackDEO : DamageEffectObject
{
    [SerializeField] private float force = 10f;
    [SerializeField] private float duration = 0.75f;
    [SerializeField] private float decelerationSpeed = 30f;

    public override void ApplyEffect(GameObject sender, GameObject receiver)
    {
        Vector2 knockbackDirection = (receiver.transform.position - sender.transform.position).normalized;
        receiver.GetComponentInChildren<KnockbackHandler>().Apply(knockbackDirection, force, duration, decelerationSpeed);
    }
}