using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetSliderDescriptor : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    [Header("Text")]
    [SerializeField] private string _veryLeft;
    [SerializeField] private string _littleLeft;
    [SerializeField] private string _neutral;
    [SerializeField] private string _littleRight;
    [SerializeField] private string _veryRight;

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
