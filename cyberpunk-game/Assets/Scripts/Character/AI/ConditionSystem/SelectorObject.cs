using UnityEngine;

[CreateAssetMenu(fileName = "NewSelector", menuName = "Scriptable Objects/Conditions/Selector")]
public class SelectorObject : ConditionObject
{
    [SerializeField] private ConditionObject[] conditions;

    public override bool Evaluate(GameObject master, GameObject obj)
    {
        bool result = false;

        if (conditions != null && conditions.Length > 0)
        {
            for (int i = 0; i < conditions.Length && !result; i++)
            {
                if (conditions[i] != null && conditions[i].Evaluate(master, obj))
                {
                    result = true;
                }
            }
        }

        return result;
    }
}