using DG.Tweening;
using UnityEngine;

public class OnDiedChangeColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Life life;
    [SerializeField] private Color diedColor = new Color(1, 1, 1, 0);
    [SerializeField] private float duration = 0.2f;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += PlayColorFlash;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedChangeColor script on " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= PlayColorFlash;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedChangeColor script on " + gameObject.name);
        }
    }

    private void PlayColorFlash()
    {
        spriteRenderer.DOKill();

        Sequence colorSequence = DOTween.Sequence();
        colorSequence.Append(spriteRenderer.DOColor(diedColor, duration));
    }
}