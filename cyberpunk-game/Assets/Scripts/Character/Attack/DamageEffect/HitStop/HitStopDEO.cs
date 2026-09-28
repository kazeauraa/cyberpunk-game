using UnityEngine;

[CreateAssetMenu(fileName = "New Hit Stop Effect", menuName = "Scriptable Objects/Damage Effects/Hit Stop")]
public class HitStopDEO : DamageEffectObject
{
    [SerializeField] private float duration = 0.1f;

    public override void ApplyEffect(GameObject sender, GameObject receiver)
    {
        HitStopManager.Instance.ApplyHitStop(duration);
    }
}