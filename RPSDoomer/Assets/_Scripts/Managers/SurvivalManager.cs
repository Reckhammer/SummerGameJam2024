using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.FindAnyObjectByType<PlayerMove>().GetComponent<Health>();
    }

    private void Start()
    {
        playerHealth.Death += ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverMenu.SetActive(true);

        StartCoroutine(ReturnToMainMenuScene());
    }

    private IEnumerator ReturnToMainMenuScene()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainMenu_Scene");
    }
}
