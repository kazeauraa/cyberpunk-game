using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public event System.Action<string> OnLoading;

    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        OnLoading?.Invoke(sceneName);

        SceneManager.LoadScene(sceneName);
    }

    public void SetSceneName(string sceneName)
    {
        this.sceneName = sceneName;
    }
}
