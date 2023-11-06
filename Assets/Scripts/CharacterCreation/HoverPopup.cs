using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverPopup : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI _headerWhite;
    [SerializeField] private TextMeshProUGUI _headerShadow;
    [SerializeField] private TextMeshProUGUI _body;

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

    public void DisablePopup()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        // set position to mouse position
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }
}
