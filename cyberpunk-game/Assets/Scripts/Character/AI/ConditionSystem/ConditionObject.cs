using UnityEngine;

public abstract class ConditionObject : ScriptableObject
{
    public abstract bool Evaluate(GameObject master, GameObject obj);
}