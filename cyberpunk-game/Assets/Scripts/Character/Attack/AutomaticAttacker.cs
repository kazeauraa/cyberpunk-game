using UnityEngine;

public class AutomaticAttacker : MonoBehaviour
{
    [SerializeField] private float interval = 1f;
    [SerializeField] private AttackAction attackAction;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            if (attackAction != null)
            {
                attackAction.TryAttack();
            }
        }
    }
}