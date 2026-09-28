using UnityEngine;

[CreateAssetMenu(fileName = "NewInverter", menuName = "Scriptable Objects/Conditions/Inverter")]
public class InverterObject : ConditionObject
{
    [SerializeField] private ConditionObject condition;

    public override bool Evaluate(GameObject master, GameObject obj)
    {
        bool result = false;

        if (condition != null)
        {
            result = !condition.Evaluate(master, obj);
        }

        return result;
    }
}