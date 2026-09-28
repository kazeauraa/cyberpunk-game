using UnityEngine;

public abstract class DamageEffectObject : ScriptableObject
{
    public abstract void ApplyEffect(GameObject sender, GameObject receiver);
}