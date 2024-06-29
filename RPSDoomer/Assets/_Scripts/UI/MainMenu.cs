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
        SceneManager.LoadScene("WorldMap");
    }

    public void OnQuitClickedClicked()
    {
        Application.Quit();   
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnCreditsButtonClicked()
    {
        SceneManager.LoadScene("Credits");
    }
}
