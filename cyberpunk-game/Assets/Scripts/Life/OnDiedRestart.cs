using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDiedRestart : MonoBehaviour
{
    [SerializeField] private Life life;
    [SerializeField] private float delay = 2f;

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
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
