using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] float movementTime = 1f;
    private Animator anim;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    

    void Start()
    {
        anim = GetComponent<Animator>();
        this.transform.localPosition = new Vector3(-3500f, 0f, 0f);
    }

    void Update()
    {

    }

    public void GoToNextScene()
    {
        GameManager.Instance.SetTransitionDirection(true);
        anim.Play("ToNextScene", 0, 0);
    }

    public void ArriveAtNextScene()
    {
        anim.Play("AtNextScene", 0, 0);
    }

    public void GoToPrevScene()
    {
        GameManager.Instance.SetTransitionDirection(false);
        anim.Play("ToPrevScene", 0, 0);
    }

    public void ArriveAtPrevScene()
    {
        anim.Play("AtPrevScene", 0, 0);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) // Not really sure about these paramenters, but they're required, so sure?
    {
        // When the level is loaded:
        anim = GetComponent<Animator>();
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.GetTransitionDirection())
            {
                anim.Play("AtNextScene", 0, 0);
            }
            else
            {
                anim.Play("AtPrevScene", 0, 0);
            }
        }
       

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
