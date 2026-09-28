using UnityEngine;

[CreateAssetMenu(fileName = "NewRangedAttack", menuName = "Scriptable Objects/Attacks/Ranged")]
public class RangedAttackObject : ScriptableObject
{
    [SerializeField] private AttackData data;
    [SerializeField] private string bulletId = "BulletId";
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField, Min(1)] private int pierce = 1;

    public AttackData Data => data;
    public string BulletId => bulletId;
    public float BulletSpeed => bulletSpeed;
    public int Pierce => pierce;
}