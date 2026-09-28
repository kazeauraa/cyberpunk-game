using UnityEngine;

public class OnTriggerHeal : MonoBehaviour
{
    [SerializeField] private TriggerArea triggerArea;
    [SerializeField] private int amount = 1;

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
        if (collisionObj == null) return;

        var life = collisionObj.GetComponentInChildren<Life>();

        if (life == null)
        {
            Debug.LogWarning($"No Life component found on {collisionObj.name} or its children.", collisionObj);
            return;
        }

        bool healed = life.Heal(amount);

        if (!healed)
        {
            Debug.Log($"Heal of {amount} on {collisionObj.name} had no effect.", collisionObj);
        }
    }
}
