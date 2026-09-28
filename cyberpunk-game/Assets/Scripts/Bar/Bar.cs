using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Image fillImage;

    private float maxValue = 100f;
    private float targetFillAmount;
    private bool shouldAnimate = false;

    public float CurrentValue
    {
        get
        {
            if (shouldAnimate)
            {
                return targetFillAmount;
            }
            else
            {
                return fillImage.fillAmount;
            }
        }
    }
    public float MaxValue => maxValue;

    void Update()
    {
        if (!shouldAnimate || fillImage == null) return;

        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetFillAmount, Time.deltaTime * smoothSpeed);

        // Stop animating when close enough to target
        if (Mathf.Abs(fillImage.fillAmount - targetFillAmount) < 0.001f)
        {
            fillImage.fillAmount = targetFillAmount;
            shouldAnimate = false;
        }
    }

    public void SetMaxValue(float maxValue)
    {
        if (maxValue <= 0)
        {
            Debug.LogWarning("Max value must be greater than 0");
            return;
        }

        this.maxValue = maxValue;
    }

    public void SetValue(float value, bool playAnimation = false)
    {
        shouldAnimate = playAnimation;
        targetFillAmount = Mathf.Clamp01(value / maxValue);

        if (!shouldAnimate && fillImage != null)
        {
            fillImage.fillAmount = targetFillAmount;
        }
    }
}