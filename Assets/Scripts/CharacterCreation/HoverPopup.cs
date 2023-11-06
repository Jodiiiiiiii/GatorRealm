using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HoverPopup : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI _headerWhite;
    [SerializeField] private TextMeshProUGUI _headerShadow;
    [SerializeField] private TextMeshProUGUI _body;

    private void Update()
    {
        // set position to mouse position
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }

    public void SetBody(string bodyText)
    {
        _body.text = bodyText;
    }

    public void SetHeader(string headerText)
    {
        _headerWhite.text = headerText;
        _headerShadow.text = headerText;
    }

    public void EnablePopup()
    {
        gameObject.SetActive(true);
    }

    public void SurveyErrorPopup(Button button)
    {
        if(!button.interactable)
        {
            SetHeader("Unable to Submit");
            SetBody("You must answer all survey questions before you can submit");
            EnablePopup();
        }
    }

    public void FinalizeErrorPopup(Button button)
    {
        if (!button.interactable)
        {
            SetHeader("Unable to Submit");
            SetBody("You must select a class before you can finalize");
            EnablePopup();
        }
    }

    public void DisablePopup()
    {
        gameObject.SetActive(false);
    }

    
}
