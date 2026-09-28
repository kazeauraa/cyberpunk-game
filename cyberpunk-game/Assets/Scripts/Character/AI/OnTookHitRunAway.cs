using UnityEngine;

public class OnTookHitRunAway : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private RunAwayFlag runAwayFlag;

    private void OnEnable()
    {
        life.OnTookHit += HandleTookHit;
    }

    private void OnDisable()
    {
        life.OnTookHit -= HandleTookHit;
    }

    private void HandleTookHit(int damage)
    {
        runAwayFlag.SetActive();
    }
}
