using UnityEngine;

[CreateAssetMenu(fileName = "NewRunAwayConditionObject", menuName = "Scriptable Objects/Conditions/Specific/RunAway")]
public class RunAwayConditionObject : ConditionObject
{
    public override bool Evaluate(GameObject master, GameObject obj)
    {
        bool result = false;

        if (obj != null)
        {
            RunAwayFlag runAwayFlag = obj.GetComponent<RunAwayFlag>();

            if (runAwayFlag != null)
            {
                result = runAwayFlag.Flag;
            }
            else
            {
                Debug.LogWarning($"Object {obj.name} does not have a RunAwayFlag component.");
            }
        }

        return result;
    }
}
