using System;
using UnityEngine;

public abstract class AIBehaviour : MonoBehaviour
{
    public event Action OnInitialized;
    public event Action OnStopped;

    [SerializeField] private ConditionObject condition;
    [SerializeField] private int priority;
    [SerializeField] private GameObject master;

    public int Priority => priority;

    public bool CanExecute
    {
        get
        {
            bool result = true;

            if (condition != null)
            {
                result = condition.Evaluate(master, gameObject);
            }

            return result;
        }
    }

    public virtual void Initialize()
    {
        OnInitialized?.Invoke();
    }

    public abstract void Execute();

    public virtual void Stop()
    {
        OnStopped?.Invoke();
    }
}