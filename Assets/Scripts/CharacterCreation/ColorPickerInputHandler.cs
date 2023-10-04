using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Extras;

public class ColorPickerInputHandler : MonoBehaviour
{
    [SerializeField] private InputField colorInput;

    private int _colorIndex = -1; // -1 indicates no color currently picked

    // called every frame that the color changes
    public void UpdateColor()
    {
        switch (_colorIndex)
        {
            case 0: // skin color
                GameManager.Instance.GetCharacter().SkinColor = Convert.ToInt32(colorInput.text[1..], 16);
                break;
            case 1: // hair color
                GameManager.Instance.GetCharacter().HairColor = Convert.ToInt32(colorInput.text[1..], 16);
                break;
            case 2: // shirt color 1
                GameManager.Instance.GetCharacter().ShirtColor1 = Convert.ToInt32(colorInput.text[1..], 16);
                break;
            case 3: // shirt color 2
                GameManager.Instance.GetCharacter().ShirtColor2 = Convert.ToInt32(colorInput.text[1..], 16);
                break;
            case 4: // pants color
                GameManager.Instance.GetCharacter().PantsColor = Convert.ToInt32(colorInput.text[1..], 16);
                break;
            case 5: // shoes color
                GameManager.Instance.GetCharacter().ShoesColor = Convert.ToInt32(colorInput.text[1..], 16);
                break;
            default: // none selected
                break;
        }
    }

    /// <summary>
    /// opens new color picker;
    /// sets starting color of new picker;
    /// sets position of new picker
    /// </summary>
    public void OpenNewPicker(int colorIndex)
    {
        _colorIndex = colorIndex;

        // set initial value of new color picker
        switch(colorIndex)
        {
            case 0: // skin color
                GetComponent<FlexibleColorPicker>().SetColor(HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().SkinColor));
                break;
            case 1: // hair color
                GetComponent<FlexibleColorPicker>().SetColor(HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().HairColor));
                break;
            case 2: // shirt color 1
                GetComponent<FlexibleColorPicker>().SetColor(HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShirtColor1));
                break;
            case 3: // shirt color 2
                GetComponent<FlexibleColorPicker>().SetColor(HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShirtColor2));
                break;
            case 4: // pants color
                GetComponent<FlexibleColorPicker>().SetColor(HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().PantsColor));
                break;
            case 5: // shoes color
                GetComponent<FlexibleColorPicker>().SetColor(HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShoesColor));
                break;
            default: // none selected
                break;
        }
    }

    public int GetColorIndex()
    {
        return _colorIndex;
    }

    public void SetColor(Color color)
    {
        GetComponent<FlexibleColorPicker>().SetColor(color);
    }
}
