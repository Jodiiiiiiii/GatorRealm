using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Extras;

/// <summary>
/// Used to update colors of color picker buttons
/// </summary>
public class DisplayColorOnButton : MonoBehaviour
{
    [SerializeField] private int _colorIndex = -1;

    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // update color based on color index
        switch (_colorIndex)
        {
            case 0: // skin color
                _image.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().SkinColor);
                break;
            case 1: // hair color
                _image.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().HairColor);
                break;
            case 2: // shirt color 1
                _image.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShirtColor1);
                break;
            case 3: // shirt color 2
                _image.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShirtColor2);
                break;
            case 4: // pants color
                _image.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().PantsColor);
                break;
            case 5: // shoes color
                _image.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShoesColor);
                break;
            default: // none selected
                break;
        }
    }
}
