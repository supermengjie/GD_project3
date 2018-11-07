using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool IsGamePaused = false;
    public GameObject pauseMenuUI;

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(IsGamePaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("loading menu");
        SceneManager.LoadScene("menu");
    }
    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
