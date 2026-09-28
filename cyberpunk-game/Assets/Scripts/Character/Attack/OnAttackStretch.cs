using DG.Tweening;
using UnityEngine;

public class OnAttackStretch : MonoBehaviour
{
    [SerializeField] private AttackAction attackAction;
    [SerializeField] private Transform master;
    [SerializeField] private Vector2 stretchScale = new Vector2(0.85f, 1f);
    [SerializeField] private float stretchDuration = 0.1f;
    [SerializeField] private float returnDuration = 0.1f;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = master != null ? master.localScale : Vector3.one;
    }

    private void OnEnable()
    {
        attackAction.OnAttackStarted += HandleAttackStarted;
    }

    private void OnDisable()
    {
        attackAction.OnAttackStarted -= HandleAttackStarted;
    }

    private void HandleAttackStarted()
    {
        DOTween.Kill(master);

        DOTween.Sequence()
            .Append(master.DOScale(stretchScale, stretchDuration))
            .Append(master.DOScale(originalScale, returnDuration));
    }
}
