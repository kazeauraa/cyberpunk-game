using UnityEngine;

[CreateAssetMenu(fileName = "NewFlagConditionObject", menuName = "Scriptable Objects/Conditions/Specific/Flag")]
public class FlagConditionObject : ConditionObject
{
    public override bool Evaluate(GameObject master, GameObject obj)
    {
        bool result;
        if (obj.TryGetComponent(out TimeFlagSetter flagSetter))
        {
            result = flagSetter.Flag;
        }
        else
        {
            Debug.LogWarning($"Object {obj.name} does not have a TimeFlagSetter component.");
            result = false;
        }

        return result;
    }
}