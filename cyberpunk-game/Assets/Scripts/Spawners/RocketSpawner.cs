using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private string rocketId = "Rocket";
    [SerializeField] private float spawnRate = 10f;
    [SerializeField] private Vector2 offset = new Vector2(2f, 0.5f);
    private float spawnTimer;

    void Start()
    {
        spawnTimer = 0f;

        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            Vector2 outsidePos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0, Camera.main.transform.position.z * -1));
            Vector2 spawnPos = new Vector2(outsidePos.x, player.position.y);
            PoolManager.Instance.Instantiate(rocketId, spawnPos + offset);
            spawnTimer = 0f;
        }
    }
}