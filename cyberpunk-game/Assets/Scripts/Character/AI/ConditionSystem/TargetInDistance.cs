using UnityEngine;

[CreateAssetMenu(fileName = "NewTargetInDistance", menuName = "Scriptable Objects/Conditions/Specific/Target In Distance")]
public class TargetInDistance : ConditionObject
{
    public override bool Evaluate(GameObject master, GameObject obj)
    {
        bool result = false;

        if (obj != null)
        {
            TargetProvider targetProvider = obj.GetComponent<TargetProvider>();
            TargetInformation information = obj.GetComponent<TargetInformation>();

            if (information != null && targetProvider != null && targetProvider.Target != null)
            {
                Vector2 objPosition = obj.transform.position;
                Vector2 targetPosition = targetProvider.Target.position;
                float currentDistance = Vector2.Distance(objPosition, targetPosition);

                if (currentDistance <= information.DistanceToApproach)
                {
                    result = true;
                }
            }
        }

        return result;
    }
}