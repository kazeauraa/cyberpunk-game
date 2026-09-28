using UnityEngine;

public class OnDiedUnvalidateTarget : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private TargetValidator targetValidator;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += HandleValidateTarget;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= HandleValidateTarget;
        }
    }

    private void HandleValidateTarget()
    {
        if (targetValidator != null)
        {
            targetValidator.Valid = false;
        }
    }
}