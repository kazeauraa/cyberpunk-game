using System;
using UnityEngine;

public class TargetContext : MonoBehaviour
{
    public event Action OnTargetChanged;

    private Transform target;

    public Transform Target
    {
        get
        {
            return target;
        }
        set
        {
            if (target != value)
            {
                target = value;
                OnTargetChanged?.Invoke();
            }
        }
    }
}