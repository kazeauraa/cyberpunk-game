using UnityEngine;

public class OnDiedPauseGame : MonoBehaviour
{
    [SerializeField] private Life life;

    private void Awake()
    {
        if (life == null)
        {
            life = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Life>();
        }

        if (life == null)
        {
            Debug.LogError("Life component not found!", this);
        }
    }

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += HandleOnDied;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= HandleOnDied;
        }
    }

    private void HandleOnDied()
    {
        Time.timeScale = 0f; // Pauses the game
        Debug.Log("Game paused due to OnDied event.");
    }
}