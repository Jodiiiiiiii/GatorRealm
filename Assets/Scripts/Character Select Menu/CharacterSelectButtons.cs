using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectButtons : MonoBehaviour
{
    [SerializeField] ScreenTransition screenTransition;
    public void BackButton()
    {
        StopAllCoroutines();
        StartCoroutine(DoBackToMain());
    }

    public void NewCharaButton()
    {
        StopAllCoroutines();
        StartCoroutine(DoNewChara());
    }

    private IEnumerator DoBackToMain()
    {
        screenTransition.GoToPrevScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator DoNewChara()
    {
        screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
