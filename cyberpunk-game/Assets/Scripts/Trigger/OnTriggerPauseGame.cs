using UnityEngine;

public class OnTriggerPauseGame : MonoBehaviour
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
        Time.timeScale = 0f; // Pauses the game
        Debug.Log("Game paused due to OnTrigger event.");
    }
}