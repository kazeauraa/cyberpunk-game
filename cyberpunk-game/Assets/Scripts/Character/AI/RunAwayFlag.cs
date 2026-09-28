using System.Collections;
using UnityEngine;

public class RunAwayFlag : MonoBehaviour
{
    [SerializeField] private float duration = 3f;

    public bool Flag { get; private set; }

    public void SetActive()
    {
        StartCoroutine(RunAwayCoroutine());
    }

    private IEnumerator RunAwayCoroutine()
    {
        Flag = true;
        yield return new WaitForSeconds(duration);
        Flag = false;
    }
}
