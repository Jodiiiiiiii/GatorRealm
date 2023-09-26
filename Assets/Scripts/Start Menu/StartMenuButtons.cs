using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    [SerializeField] CameraControl control;
    [SerializeField] ScreenTransition screenTransition;
    public void StartButton()   // Loads the character select screen
    {
        // TODO: Add a scene transition effect
       StartCoroutine(DoStartGame());
    }

    public void CreditsButton()
    {
        control.SetCamCredits();
    }

    public void CreditsBackButton()
    {
        control.SetCamMain();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    private IEnumerator DoStartGame()
    {
        screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
