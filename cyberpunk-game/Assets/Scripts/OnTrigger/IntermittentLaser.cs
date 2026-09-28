using UnityEngine;

public class IntermittentLaser : MonoBehaviour
{
    [SerializeField] private GameObject laserVisual;
    [SerializeField] private Collider2D col;
    [SerializeField] private float interval = 1f;

    private float timer;
    private bool active = true;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            active = !active;
            laserVisual.SetActive(active);
            col.enabled = active;
        }
    }
}