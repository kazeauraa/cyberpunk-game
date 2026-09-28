using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerArea : MonoBehaviour
{
    public event Action<GameObject> OnTrigger;

    [SerializeField] private string[] targetTags = { "Player" };

    [SerializeField] private bool once;

    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var tag in targetTags)
        {
            if (collision.CompareTag(tag))
            {
                OnTrigger?.Invoke(collision.gameObject);

                if (once)
                {
                    GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }
}
