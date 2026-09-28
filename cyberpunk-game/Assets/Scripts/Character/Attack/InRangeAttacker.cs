using UnityEngine;

public class InRangeAttacker : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private AttackAction attackAction;
    [SerializeField] private RangeDetector rangeDetector;

    private Transform target;
    private float cooldownTimer;

    private void Start()
    {
        GameObject targetObj = GameObject.FindWithTag(targetTag);

        if (targetObj != null)
        {
            target = targetObj.transform;
        }
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (target != null && cooldownTimer <= 0f && rangeDetector.Detected)
        {
            if (attackAction.TryAttack())
            {
                cooldownTimer = attackCooldown;
            }
        }
    }
}
