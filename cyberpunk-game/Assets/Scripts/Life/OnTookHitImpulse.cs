using Unity.Cinemachine;
using UnityEngine;

public class OnTookHitImpulse : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private CinemachineImpulseSource impulseSource;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnTookHit += GenerateImpulse;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnTookHit -= GenerateImpulse;
        }
    }

    private void GenerateImpulse(int damage)
    {
        impulseSource.GenerateImpulse();
    }
}