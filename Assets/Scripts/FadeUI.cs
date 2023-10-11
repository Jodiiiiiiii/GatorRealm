/*
Fade UI
Used on:    Menus and menu elements
For:    Holds methods for fading and unfading UI elements (battle UI)
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeUI : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void UIFadeIn()  // Methods used for the battle UI
    {
        StopAllCoroutines();
        StartCoroutine(DoFadeInUI());
    }

    public void UIFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(DoFadeOutUI());
    }

    IEnumerator DoFadeInUI()
    {
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime * 3f;
            yield return null;
        }

    }
    IEnumerator DoFadeOutUI()
    {                           
        while (canvasGroup.alpha > 0f)
        {
            Debug.Log(canvasGroup.alpha);
            canvasGroup.alpha -= Time.deltaTime * 3f;
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}


