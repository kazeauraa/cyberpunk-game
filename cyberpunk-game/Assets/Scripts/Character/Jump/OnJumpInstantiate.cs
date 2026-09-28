using UnityEngine;

public class OnJumpInstantiate : MonoBehaviour
{
    [SerializeField] private JumpAction jumpAction;
    [SerializeField] private string objId;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        if (jumpAction == null)
        {
            Debug.LogError("JumpAction is not assigned in OnJumpInstantiate");
        }

        if (spawnPoint == null)
        {
            Debug.LogError("SpawnPoint is not assigned in OnJumpInstantiate");
        }
    }

    private void OnEnable()
    {
        jumpAction.OnStartedJump += HandleJumpStarted;
    }

    private void OnDisable()
    {
        jumpAction.OnStartedJump -= HandleJumpStarted;
    }

    private void HandleJumpStarted()
    {
        PoolManager.Instance.Instantiate(objId, spawnPoint.position);
    }
}