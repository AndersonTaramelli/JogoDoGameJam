using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private string nameOfGame;

    [SerializeField] private GameObject painelMainMenu;
    [SerializeField] private GameObject painelSettings;

    public void Play()
    {
        SceneManager.LoadScene(nameOfGame);
    }

    public void OpenSettings()
    {
        painelMainMenu.SetActive(false);
        painelSettings.SetActive(true);
    }

    public void CloseSettings()
    {
        painelSettings.SetActive(false);
        painelMainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}