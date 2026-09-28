using UnityEngine;

public class OnHoldReachedSound : MonoBehaviour
{
    [SerializeField] private AttackInput attackInput;
    [SerializeField] private string soundId;

    private void OnEnable()
    {
        if (attackInput != null)
        {
            attackInput.OnHoldReached += PlaySound;
        }
    }

    private void OnDisable()
    {
        if (attackInput != null)
        {
            attackInput.OnHoldReached -= PlaySound;
        }
    }

    private void PlaySound()
    {
        float randomPitch = Random.Range(0.9f, 1.1f);
        AudioManager.Instance.PlaySound(soundId, transform.position, randomPitch);
    }
}