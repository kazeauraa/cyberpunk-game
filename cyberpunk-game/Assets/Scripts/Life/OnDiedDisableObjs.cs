using UnityEngine;

public class OnDiedDisableObjs : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private GameObject[] objects;

    private void OnEnable()
    {
        life.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        life.OnDied -= HandleDied;
    }

    private void HandleDied()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}