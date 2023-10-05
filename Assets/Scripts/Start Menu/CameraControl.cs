using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // X, Y, and Z camera position modifers for different interactions in the game
    [SerializeField] Vector3 mainMenuPos = new Vector3(0f, 0f, -1f);
    [SerializeField] Vector3 creditsPos = new Vector3(0f, 10f, -1f);

    [SerializeField] float movementTime = .75f; // A time (sec) value

    private bool activeCoroutine;

    void Start()
    {
        activeCoroutine = false;
    }

    void Update()
    {

    } 

    public void SetCamCredits()
    {
        StopAllCoroutines();
        StartCoroutine(DoCamPosition(creditsPos, movementTime));
    }

    public void SetCamMain()
    {
        StopAllCoroutines();
        StartCoroutine(DoCamPosition(mainMenuPos, movementTime));
    }
    IEnumerator DoCamPosition(Vector3 targetPos, float step)
    {
        activeCoroutine = true;

        Vector3 velocity = Vector3.zero;    // Initial velocity values for the damping functions

        while (Vector3.Distance(transform.position, targetPos) >= .05f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, step); // Move camera position
            yield return null;
        }
        activeCoroutine = false;
        yield return null;
    }

}
