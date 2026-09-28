using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float delay;

    private void Start()
    {
        Execute();
    }

    public void Execute()
    {
        Destroy(gameObject, delay);
    }
}