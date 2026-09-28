using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 144;

    void Awake()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = targetFrameRate;
    }
}
