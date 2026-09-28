using DG.Tweening;
using UnityEngine;

public class OnTookHitSquashNStretch : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private Transform master;

    [SerializeField] private Vector2 startScale;
    [SerializeField] private Vector2 finalScale;

    private Vector2 originalScale;
    private bool tweening;

    private void Awake()
    {
        originalScale = master != null ? master.localScale : Vector2.one;
        tweening = false;
    }

    private void OnEnable()
    {
        life.OnTookHit += HandleTookHit;
    }

    private void OnDisable()
    {
        life.OnTookHit -= HandleTookHit;
    }

    private void HandleTookHit(int damage)
    {
        if (!tweening)
        {
            tweening = true;

            Tween();
        }
        else
        {
            DOTween.Kill(master);
            master.localScale = originalScale;
            Tween();
        }
    }

    private void Tween()
    {
        DOTween.Sequence()
            .Append(master.DOScale(startScale, 0.1f))
            .Append(master.DOScale(finalScale, 0.1f))
            .Append(
                master.DOScale(originalScale, 0.1f)
                .OnComplete(() => tweening = false)
            );
    }
}