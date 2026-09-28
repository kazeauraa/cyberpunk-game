using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour
{
    [SerializeField] GameObject oldPanel;
    [SerializeField] GameObject newPanel;

    [Space(20)]
    [SerializeField] private GameObject selectedGameObject;

    public void OpenPanel()
    {
        oldPanel.SetActive(false);
        newPanel.SetActive(true);

        if (selectedGameObject != null)
        {
            EventSystem.current.SetSelectedGameObject(selectedGameObject);
        }
    }

    public void OpenOnePanel()
    {
        newPanel.SetActive(true);

        if (selectedGameObject != null)
        {
            EventSystem.current.SetSelectedGameObject(selectedGameObject);
        }
    }

    public void ClosePanel()
    {
        oldPanel.SetActive(false);

        if (selectedGameObject != null)
        {
            EventSystem.current.SetSelectedGameObject(selectedGameObject);
        }
    }
}
