using UnityEngine;

public class OnTriggerPlayMusic : MonoBehaviour
{
    [SerializeField] private TriggerArea triggerArea;
    [SerializeField] private string musicId;

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
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("AudioManager instance not found.");
            return;
        }

        if (string.IsNullOrEmpty(musicId))
        {
            Debug.LogWarning("Music ID is empty on OnTriggerPlayMusic.");
            return;
        }

        AudioManager.Instance.PlayMusic(musicId);
    }
}
