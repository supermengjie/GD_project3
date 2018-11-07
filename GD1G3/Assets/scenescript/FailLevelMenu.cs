using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailLevelMenu : MonoBehaviour
{

    public static bool IsGamePaused = false;
    public GameObject LevelCompMenuUI;
    public bool dead = false;
    public string sceneLevel;


    void Update()
    {

    }

    public void nextLeve()
    {
        // Time.timeScale = 1f;
        dead = false;
        SceneManager.LoadScene(sceneLevel);
    }


    public void loadMenu()
    {
        // Time.timeScale = 1f;
        dead = false;
        Debug.Log("loading menu");
        SceneManager.LoadScene("menu");
    }
    public void quitGame()
    {

        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
