using System.Collections;
using UnityEngine;

public class AttackTemporaryEnabler : MonoBehaviour
{
    [SerializeField] private AttackAction attackAction;
    [SerializeField] private GameObject obj;
    [SerializeField] private float duration;

    private Coroutine disableCoroutine;

    private void OnEnable()
    {
        if (attackAction != null)
        {
            attackAction.OnAttackStarted += EnableObject;
        }
    }

    private void OnDisable()
    {
        if (attackAction != null)
        {
            attackAction.OnAttackStarted -= EnableObject;
        }
    }

    private void EnableObject()
    {
        if (disableCoroutine != null)
        {
            StopCoroutine(disableCoroutine);
        }

        obj.SetActive(true);
        disableCoroutine = StartCoroutine(DisableAfterDuration());
    }

    private IEnumerator DisableAfterDuration()
    {
        yield return new WaitForSeconds(duration);
        obj.SetActive(false);
        disableCoroutine = null;
    }
}
