using System.Collections;
using UnityEngine;

public class HitStopManager : MonoBehaviour
{
    public static HitStopManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ApplyHitStop(float duration)
    {
        if (duration > 0f && Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
            StartCoroutine(RestoreTimeAfter(duration));
        }
    }

    private IEnumerator RestoreTimeAfter(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}