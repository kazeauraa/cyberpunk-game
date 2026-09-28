using UnityEngine;

public class OnTriggerTimeScale : MonoBehaviour
{
    [SerializeField] private TriggerArea triggerArea;
    [SerializeField] private float timeScale = 1f;

    private void Awake()
    {
        if (triggerArea == null)
        {
            GameObject finishLine = GameObject.FindGameObjectWithTag("FinishLine");

            if (finishLine != null)
            {
                triggerArea = finishLine.GetComponent<TriggerArea>();
            }
            else
            {
                Debug.LogError("TriggerArea not assigned and no GameObject with tag 'FinishLine' found!", this);
            }
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
        Time.timeScale = timeScale;
    }
}
