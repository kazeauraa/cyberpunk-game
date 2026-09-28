using System.Collections;
using UnityEngine;

public class OnAttackVFX : MonoBehaviour
{
    [SerializeField] private AttackAction attackAction;
    [SerializeField] private GameObject vfx;
    [SerializeField] private float duration = 1f;

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
        if (vfx != null)
        {
            StartCoroutine(ShowVFX());
        }
    }

    private IEnumerator ShowVFX()
    {
        vfx.SetActive(true);
        yield return new WaitForSeconds(duration);
        vfx.SetActive(false);
    }
}
