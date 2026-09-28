using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;

    bool hasStarted;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        hasStarted = false;
    }

    public void SetSound(AudioClip clip, float pitch = 1f)
    {
        audioSource.clip = clip;
        audioSource.pitch = pitch;
        audioSource.Play();

        hasStarted = true;
    }

    void Update()
    {
        if (!audioSource.isPlaying && hasStarted)
            Disable();
    }

    void Disable()
    {
        gameObject.SetActive(false);
        hasStarted = false;

        PoolManager.Instance.AddToPool("sound", gameObject);
    }
}