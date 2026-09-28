using UnityEngine;

public class GOKnockbackHandler : MonoBehaviour
{
    [SerializeField] private KnockbackHandler knockbackHandler;
    [SerializeField] private GameObject[] objs;

    private void OnEnable()
    {
        if (knockbackHandler != null)
        {
            knockbackHandler.OnKnockbackApplied += HandleOnKnockbackApplied;
            knockbackHandler.OnKnockbackStopped += HandleOnKnockbackStopped;
        }
        else
        {
            Debug.LogError("GOsKnockbackHandler: KnockbackHandler reference is null on GameObject " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (knockbackHandler != null)
        {
            knockbackHandler.OnKnockbackApplied -= HandleOnKnockbackApplied;
            knockbackHandler.OnKnockbackStopped -= HandleOnKnockbackStopped;
        }
    }

    private void HandleOnKnockbackApplied()
    {
        if (objs != null)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] != null)
                {
                    objs[i].SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogWarning("GOsKnockbackHandler: objs array is null on GameObject " + gameObject.name);
        }
    }

    private void HandleOnKnockbackStopped()
    {
        if (objs != null)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] != null)
                {
                    objs[i].SetActive(true);
                }
            }
        }
        else
        {
            Debug.LogWarning("GOsKnockbackHandler: objs array is null on GameObject " + gameObject.name);
        }
    }
}