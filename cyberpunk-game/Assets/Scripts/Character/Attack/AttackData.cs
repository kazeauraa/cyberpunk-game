using UnityEngine;

[System.Serializable]
public class AttackData
{
    [SerializeField] private string id = "Id";
    [SerializeField] private int damage = 10;
    [SerializeField] private float actionExecutionTime = 0.1f;
    [SerializeField] private float cooldown = 0.5f;

    public AttackData(string id, int damage, float actionExecutionTime, float cooldown)
    {
        this.id = id;
        this.damage = damage;
        this.actionExecutionTime = actionExecutionTime;
        this.cooldown = cooldown;
    }

    public string Id => id;
    public int Damage => damage;
    public float ActionExecutionTime => actionExecutionTime;
    public float Cooldown => cooldown;
}