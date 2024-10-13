using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject resultUI;
    [SerializeField] GameObject gameoverUI;

    private void Start()
    {
        ToggleResultUIVisibility(false);
        ToggleGameOverUIVisibility(false);
    }

    public void ToggleResultUIVisibility(bool visibility)
    {
        resultUI.SetActive(visibility);
    }
    public void ToggleGameOverUIVisibility(bool visibility)
    {
        gameoverUI.SetActive(visibility);
    }

    public void OnNextStageButton()
    {

    }
}
