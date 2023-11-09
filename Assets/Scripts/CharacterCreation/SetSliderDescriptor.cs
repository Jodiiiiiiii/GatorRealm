using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetSliderDescriptor : MonoBehaviour
{
    [Header("Components")]
    private Slider _slider;
    private TextMeshProUGUI _text;

    [Header("Text")]
    private string _veryLeft;
    private string _littleLeft;
    private string _neutral;
    private string _littleRight;
    private string _veryRight;

    // Update is called once per frame
    void Update()
    {
        if (_slider.value < 0.2f)
            _text.text = _veryLeft;
        else if (_slider.value < 0.4f)
            _text.text = _littleLeft;
        else if (_slider.value < 0.6f)
            _text.text = _neutral;
        else if (_slider.value < 0.8f)
            _text.text = _littleRight;
        else
            _text.text = _veryRight;
    }
}
