using UnityEngine;

public class OnTriggerDisableInputs : MonoBehaviour
{
    [SerializeField] private TriggerArea triggerArea;

    private void Awake()
    {
        if (triggerArea == null)
        {
            Debug.LogError("TriggerArea not assigned!", this);
        }
    }

    private void OnEnable()
    {
        if (triggerArea != null)
        {
            triggerArea.OnTrigger += HandleOnTrigger;
        }
    }

    private void OnDisable()
    {
        if (triggerArea != null)
        {
            triggerArea.OnTrigger -= HandleOnTrigger;
        }
    }

    private void HandleOnTrigger(GameObject collisionObj)
    {
        var inputs = FindObjectsByType<Input>();
        foreach (var input in inputs)
        {
            input.Disable();
        }
    }
}
