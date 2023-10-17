using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScreenButtons : MonoBehaviour
{
    private ScreenTransition screenTransition;
    
    void Start()
    {
        screenTransition = FindObjectOfType<ScreenTransition>();
    }

    public void BackButton() // Goes back to the main menu
    {
        StopAllCoroutines();
        StartCoroutine(DoBackToMain());
    }

    private IEnumerator DoBackToMain()
    {
        screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
