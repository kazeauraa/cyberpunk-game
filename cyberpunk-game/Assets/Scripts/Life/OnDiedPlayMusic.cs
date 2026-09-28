using UnityEngine;

public class OnDiedPlayMusic : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private string musicId;

    private void Awake()
    {
        if (life == null)
        {
            Debug.LogError("Life not assigned!", this);
        }

        if (string.IsNullOrEmpty(musicId))
        {
            Debug.LogError("Music ID not assigned!", this);
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
        AudioManager.Instance.PlayMusic(musicId);
    }
}