using UnityEngine;

public class RangedAttackAction : AttackAction
{
    [SerializeField] private RangedAttackObject attack;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform directionPoint;
    [SerializeField] private LayerMask bulletLayer;
    [SerializeField] private Transform master;

    public override AttackData AttackData => attack.Data;

    protected override void ExecuteAttackAction()
    {
        GameObject projectileObj = PoolManager.Instance.Instantiate(attack.BulletId, bulletSpawnPoint.position, Quaternion.identity);

        projectileObj.layer = Mathf.RoundToInt(Mathf.Log(bulletLayer.value, 2));

        Projectile projectile = projectileObj.GetComponentInChildren<Projectile>();

        Vector2 direction = (directionPoint.position - bulletSpawnPoint.position).normalized;

        projectile.Direction = direction;
        projectile.Damage = attack.Data.Damage;
        projectile.Speed = attack.BulletSpeed;
        projectile.Pierce = attack.Pierce;
    }
}