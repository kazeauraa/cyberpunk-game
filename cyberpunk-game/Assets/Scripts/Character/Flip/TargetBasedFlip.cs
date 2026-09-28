using UnityEngine;

public class TargetBasedFlip : MonoBehaviour
{
    [SerializeField] private Flip flip;
    [SerializeField] private TargetContext targetContext;

    private void OnEnable()
    {
        targetContext.OnTargetChanged += HandleTargetChanged;
    }

    private void OnDisable()
    {
        targetContext.OnTargetChanged -= HandleTargetChanged;
    }

    private void Update()
    {
        if (targetContext.Target != null)
        {
            float direction = targetContext.Target.position.x - transform.position.x;
            flip.FlipTowards(direction);
        }
    }

    private void HandleTargetChanged()
    {
        if (targetContext.Target != null)
        {
            float direction = targetContext.Target.position.x - transform.position.x;
            flip.FlipTowards(direction);
        }
    }
}
