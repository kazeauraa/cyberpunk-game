using UnityEngine;

public class OnDiedPlaySound : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private string soundId;

    private void Awake()
    {
        if (life == null)
        {
            life = FindFirstObjectByType<Life>();
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
        AudioManager.Instance?.PlaySound(soundId, Camera.main.transform.position);
    }
}
