using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("IntroVideo");
    }

    public void OnVideoSkipButtonClicked()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void OnQuitClickedClicked()
    {
        Application.Quit();   
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }

    public void OnCreditsButtonClicked()
    {
        Debug.Log("Button");
        SceneManager.LoadScene("Credits_Scene");
    }

    public void OnMainSceneButtonClicked()
    {
        SceneManager.LoadScene("Level_01");
    }
}
