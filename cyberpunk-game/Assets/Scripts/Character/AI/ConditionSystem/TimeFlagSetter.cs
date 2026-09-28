using System.Collections;
using UnityEngine;

public class TimeFlagSetter : MonoBehaviour
{
    [SerializeField] private float seconds;

    public bool Flag { get; private set; }

    private void OnEnable()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        StopAllCoroutines();
        Flag = false;
        StartCoroutine(SetFlagAfterDelay());
    }

    private IEnumerator SetFlagAfterDelay()
    {
        yield return new WaitForSeconds(seconds);
        Flag = true;
    }
}