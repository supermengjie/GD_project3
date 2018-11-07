using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{

    public GameObject tutorialUI;
    public GameObject menuUI;

    public void Back()
    {
        tutorialUI.SetActive(false);
        menuUI.SetActive(true);
    }


}
