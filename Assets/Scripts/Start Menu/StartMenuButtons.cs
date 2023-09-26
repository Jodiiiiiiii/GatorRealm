using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    public void StartButton()   // Loads the character select screen
    {
        // TODO: Add a scene transition effect
        SceneManager.LoadScene(1);
    }

    public void CreditsButton()
    {

    }

    public void CreditsBackButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
