using System;
using UnityEngine;

public class PoolGO : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private GameObject master;

    public event Action OnReturnedToPool;

    public void ReturnToPool()
    {
        OnReturnedToPool?.Invoke();
        master.SetActive(false);
        PoolManager.Instance.AddToPool(id, master);
    }
}