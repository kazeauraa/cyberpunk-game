using UnityEngine;

public class OnDiedInstantiate : MonoBehaviour
{
    [System.Serializable]
    private class DropGO
    {
        [SerializeField] private GameObject obj;
        [SerializeField, Range(0f, 1f)] private float probability;

        public GameObject Obj => obj;
        public float Probability => probability;
    }

    [SerializeField] private Life life;
    [SerializeField] private DropGO[] drops;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        if (drops == null || drops.Length == 0)
        {
            Debug.LogError("Drops array is not assigned in OnDiedInstantiate script on " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnDied += OnDied;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedInstantiate script on " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnDied -= OnDied;
        }
        else
        {
            Debug.LogError("Life component is not assigned in OnDiedInstantiate script on " + gameObject.name);
        }
    }

    private void OnDied()
    {
        float roll = Random.value;
        float cumulative = 0f;
        GameObject selected = null;

        // Pick the first drop whose cumulative probability exceeds the roll
        for (int i = 0; i < drops.Length && selected == null; i++)
        {
            cumulative += drops[i].Probability;

            if (roll <= cumulative)
            {
                selected = drops[i].Obj;
            }
        }

        if (selected != null)
        {
            Instantiate(selected, spawnPoint.position, Quaternion.identity);
        }
    }
}