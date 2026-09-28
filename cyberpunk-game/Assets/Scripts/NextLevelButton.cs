using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    private void Start()
    {
        if(SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            gameObject.SetActive(false);
            return;
        }

        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        string scenePath = SceneUtility.GetScenePathByBuildIndex(nextIndex);
        string sceneName = Path.GetFileNameWithoutExtension(scenePath);
        
        PlayerPrefs.SetInt(sceneName, 1);
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
