using System;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public event Action OnFlipped;

    [SerializeField] private Transform flippable;

    public void FlipTowards(float direction)
    {
        if (direction > 0f)
        {
            Vector3 scale = flippable.localScale;
            scale.x = Mathf.Abs(scale.x);
            flippable.localScale = scale;
        }
        else if (direction < 0f)
        {
            Vector3 scale = flippable.localScale;
            scale.x = -Mathf.Abs(scale.x);
            flippable.localScale = scale;
        }

        OnFlipped?.Invoke();
    }
}