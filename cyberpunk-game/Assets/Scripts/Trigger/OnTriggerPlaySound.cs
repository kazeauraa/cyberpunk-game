using UnityEngine;

public class OnTriggerPlaySound : MonoBehaviour
{
    [SerializeField] private TriggerArea triggerArea;
    [SerializeField] private string soundId;

    private void Awake()
    {
        if (triggerArea == null)
        {
            GameObject finishLine = GameObject.FindGameObjectWithTag("FinishLine");

            if (finishLine != null)
            {
                triggerArea = finishLine.GetComponent<TriggerArea>();

                triggerArea.OnTrigger += HandleOnTrigger;
            }
            else
            {
                Debug.LogError("TriggerArea not assigned and no GameObject with tag 'FinishLine' found!", this);
            }
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
        if (!string.IsNullOrEmpty(soundId))
        {
            AudioManager.Instance.PlaySound(soundId, Camera.main.transform.position);
        }
    }
}