using UnityEngine;

public class SpecificTargetProvider : TargetProvider
{
    [SerializeField] private Transform target;
    [SerializeField] private string targetId;

    private void Awake()
    {
        if (target == null && !string.IsNullOrEmpty(targetId))
        {
            GameObject targetObject = GameObject.FindGameObjectWithTag(targetId);
            if (targetObject != null)
            {
                target = targetObject.transform;
            }
        }
    }

    public override Transform Target => target;
}