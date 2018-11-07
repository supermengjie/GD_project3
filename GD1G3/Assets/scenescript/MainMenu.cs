using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject tutorialUI;
    public GameObject menuUI;
    public GameObject introUI;
    public void PlayGame(){
        introUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       // menuUI.SetActive(true);
    }

    public void Intro()
    {
        menuUI.SetActive(false);
        introUI.SetActive(true);
    }

    public void Tutorial()
    {
        menuUI.SetActive(false);
        tutorialUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
