using UnityEngine;

public class AttackSound : MonoBehaviour
{
    [SerializeField] private AttackAction attackAction;
    [SerializeField] private string soundId;

    private void OnEnable()
    {
        if (attackAction != null)
        {
            attackAction.OnAttackStarted += PlaySound;
        }
    }

    private void OnDisable()
    {
        if (attackAction != null)
        {
            attackAction.OnAttackStarted -= PlaySound;
        }
    }

    private void PlaySound()
    {
        float randomPitch = Random.Range(0.9f, 1.1f);
        AudioManager.Instance.PlaySound(soundId, transform.position, randomPitch);
    }
}