using UnityEngine;

[CreateAssetMenu(fileName = "NewSequence", menuName = "Scriptable Objects/Conditions/Sequence")]
public class SequenceObject : ConditionObject
{
    [SerializeField] private ConditionObject[] conditions;

    public override bool Evaluate(GameObject master, GameObject obj)
    {
        bool result = true;

        if (conditions != null && conditions.Length > 0)
        {
            for (int i = 0; i < conditions.Length && result; i++)
            {
                if (conditions[i] != null && !conditions[i].Evaluate(master, obj))
                {
                    result = false;
                }
            }
        }

        return result;
    }
}