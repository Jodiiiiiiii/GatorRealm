using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] float movementTime = 1f;

    private Animator anim;

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
        anim.Play("ToNextScene", 0, 0);
    }

    public void ArriveAtNextScene()
    {
        anim.Play("AtNextScene", 0, 0);
    }

    public void GoToPrevScene()
    {
        anim.Play("ToPrevScene", 0, 0);
    }

    public void ArriveAtPrevScene()
    {
        anim.Play("AtPrevScene", 0, 0);
    }

}
