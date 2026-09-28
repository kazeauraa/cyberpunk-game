using UnityEngine;

public class OnTookHitSound : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private string soundId;
    [SerializeField] private float minPitch = 0.9f;
    [SerializeField] private float maxPitch = 1.1f;

    private void Awake()
    {
        if (life == null)
        {
            Debug.LogError("Life component is not assigned in OnTookHitSound script on " + gameObject.name);
        }

        if (string.IsNullOrEmpty(soundId))
        {
            Debug.LogError("Sound ID is not assigned in OnTookHitSound script on " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnTookHit += PlaySound;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnTookHitSound script on " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnTookHit -= PlaySound;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnTookHitSound script on " + gameObject.name);
        }
    }

    private void PlaySound(int damage)
    {
        float randomPitch = Random.Range(minPitch, maxPitch);
        AudioManager.Instance.PlaySound(soundId, transform.position, randomPitch);
    }
}