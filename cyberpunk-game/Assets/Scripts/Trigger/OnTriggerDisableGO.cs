using UnityEngine;

public class OnTriggerDisableGO : MonoBehaviour
{
    [SerializeField] private TriggerArea triggerArea;
    [SerializeField] private GameObject targetGameObject;

    private void Awake()
    {
        if (triggerArea == null)
        {
            Debug.LogError("TriggerArea not assigned!", this);
        }

        if (targetGameObject == null)
        {
            Debug.LogError("Target GameObject not assigned!", this);
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
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }
}