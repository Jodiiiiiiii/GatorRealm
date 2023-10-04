using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetailScreen : MonoBehaviour
{
    // The movement here is copied over from CameraControl...
    // TODO: Combine CameraControl and CharacterDetail screen into a general "Moving Things" class
    // Not super essential rn tho
    [SerializeField] Vector3 visiblePos = new Vector3(0f, 0f, 0f);
    [SerializeField] Vector3 hiddenPos = new Vector3(0f, 1080f, 0f);

    [SerializeField] float movementTime = .75f; // A time (sec) value

    private bool activeCoroutine;

    void Start()
    {
        activeCoroutine = false;
    }

    void Update()
    {

    }

    public void ShowPanel()
    {
        StopAllCoroutines();
        StartCoroutine(DoPanelPosition(visiblePos, movementTime));
    }

    public void HidePanel()
    {
        StopAllCoroutines();
        StartCoroutine(DoPanelPosition(hiddenPos, movementTime));
    }
    IEnumerator DoPanelPosition(Vector3 targetPos, float step)
    {
        activeCoroutine = true;

        Vector3 velocity = Vector3.zero;    // Initial velocity values for the damping functions

        while (Vector3.Distance(transform.localPosition, targetPos) >= .05f)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPos, ref velocity, step); // Move camera position
            yield return null;
        }
        activeCoroutine = false;
        yield return null;
    }
}
