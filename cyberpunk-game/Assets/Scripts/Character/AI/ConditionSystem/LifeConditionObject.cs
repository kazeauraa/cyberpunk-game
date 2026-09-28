using UnityEngine;

[CreateAssetMenu(fileName = "NewLifeConditionObject", menuName = "Scriptable Objects/Conditions/Specific/Life")]
public class LifeConditionObject : ConditionObject
{
    [SerializeField] private int health;

    public override bool Evaluate(GameObject master, GameObject obj)
    {
        bool result = false;

        if (master != null)
        {
            Life life = master.GetComponentInChildren<Life>();

            if (life != null)
            {
                result = life.Health <= health;
            }
            else
            {
                Debug.LogWarning($"Object {master.name} does not have a Life component.");
            }
        }

        return result;
    }
}
