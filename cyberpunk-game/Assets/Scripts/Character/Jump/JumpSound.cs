using UnityEngine;

public class JumpSound : MonoBehaviour
{
    [SerializeField] private JumpAction jump;
    [SerializeField] private string soundId;

    private void OnEnable()
    {
        if (jump != null)
        {
            jump.OnStartedJump += PlayJumpSound;
        }
    }

    private void OnDisable()
    {
        if (jump != null)
        {
            jump.OnStartedJump -= PlayJumpSound;
        }
    }

    private void PlayJumpSound()
    {
        float randomPitch = Random.Range(0.9f, 1.1f);
        AudioManager.Instance.PlaySound(soundId, transform.position, randomPitch);
    }
}