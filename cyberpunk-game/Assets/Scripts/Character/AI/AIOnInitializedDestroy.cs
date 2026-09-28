using UnityEngine;

public class AIOnInitializedDestroy : MonoBehaviour
{
    [SerializeField] private AIBehaviour behaviour;
    [SerializeField] private GameObject master;
    [SerializeField] private float delay;

    private void OnEnable()
    {
        if (behaviour != null)
        {
            behaviour.OnInitialized += HandleDestroy;
        }
    }

    private void OnDisable()
    {
        if (behaviour != null)
        {
            behaviour.OnInitialized -= HandleDestroy;
        }
    }

    private void HandleDestroy()
    {
        Destroy(master, delay);
    }
}