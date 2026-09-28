using DG.Tweening;
using UnityEngine;

public class OnTookHitChangeColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Life life;
    [SerializeField] private Color takeHitColor = Color.red;
    [SerializeField] private float duration = 0.2f;

    private Color originalColor;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnTookHit += PlayColorFlash;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnTookHitChangeColor script on " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnTookHit -= PlayColorFlash;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnTookHitChangeColor script on " + gameObject.name);
        }
    }

    private void PlayColorFlash(int damage)
    {
        spriteRenderer.DOKill();

        Sequence colorSequence = DOTween.Sequence();
        colorSequence.Append(spriteRenderer.DOColor(takeHitColor, duration));
        colorSequence.Append(spriteRenderer.DOColor(originalColor, duration));
    }
}