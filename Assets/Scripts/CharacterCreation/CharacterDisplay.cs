using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Extras;

public class CharacterDisplay : MonoBehaviour
{
    // In selection mode, we need each display to be static to its own index and associated clothes
    // Whereas in creation mode, the clothes can change based on the character index in the GameManager
    private enum DisplayMode { Selection, Creation};
    [Header("Display Mode")]
    [SerializeField] private DisplayMode displayMode = DisplayMode.Selection;
    private bool loaded;

    [Header("Text Components")]
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _classText;

    [Header("Image Components")]
    [SerializeField] private Image _bodyOutline;
    [SerializeField] private Image _bodyFill;
    [SerializeField] private Image _hairOutline, _hairFill;
    [SerializeField] private Image _faceOutline;
    [SerializeField] private Image _shirtOutline, _shirtFill1, _shirtFill2;
    [SerializeField] private Image _pantsOutline, _pantsFill;
    [SerializeField] private Image _shoeOutline, _shoeFill;

    [Header("Sprites")]
    [SerializeField] private Sprite _bodyOutlineSprite;
    [SerializeField] private Sprite _bodyFillSprite;
    [SerializeField] private Sprite[] _hairOutlines, _hairFills;
    [SerializeField] private Sprite[] _faceOutlines;
    [SerializeField] private Sprite[] _shirtOutlines, _shirtFills1, _shirtFills2;
    [SerializeField] private Sprite[] _pantsOutlines, _pantsFills;
    [SerializeField] private Sprite[] _shoeOutlines, _shoeFills;

    private void Start()
    {
        _bodyOutline.sprite = _bodyOutlineSprite;
        _bodyFill.sprite = _bodyFillSprite;
        loaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(displayMode == DisplayMode.Selection && !loaded)
        {
            loaded = true;
            UpdateCharacterModel();
        }

        if (displayMode == DisplayMode.Creation)
        {
            UpdateCharacterModel();
        }

    }

    private void UpdateCharacterModel()
    {
        // update text
        _nameText.text = GameManager.Instance.GetCharacter().Name;
        _classText.text = GameManager.Instance.GetCharacter().Class;

        // update outline/fill sprites to current stored values
        _hairOutline.sprite = _hairOutlines[GameManager.Instance.GetCharacter().HairType];
        _hairFill.sprite = _hairFills[GameManager.Instance.GetCharacter().HairType];

        _faceOutline.sprite = _faceOutlines[GameManager.Instance.GetCharacter().FaceType];

        _shirtOutline.sprite = _shirtOutlines[GameManager.Instance.GetCharacter().ShirtType];
        _shirtFill1.sprite = _shirtFills1[GameManager.Instance.GetCharacter().ShirtType];
        _shirtFill2.sprite = _shirtFills2[GameManager.Instance.GetCharacter().ShirtType];

        _pantsOutline.sprite = _pantsOutlines[GameManager.Instance.GetCharacter().PantsType];
        _pantsFill.sprite = _pantsFills[GameManager.Instance.GetCharacter().PantsType];

        _shoeOutline.sprite = _shoeOutlines[GameManager.Instance.GetCharacter().ShoesType];
        _shoeFill.sprite = _shoeFills[GameManager.Instance.GetCharacter().ShoesType];

        // update fill colors based on color data
        _bodyFill.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().SkinColor);

        _hairFill.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().HairColor);

        _shirtFill1.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShirtColor1);
        _shirtFill2.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShirtColor2);

        _pantsFill.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().PantsColor);

        _shoeFill.color = HelperFunctions.IntToColor(GameManager.Instance.GetCharacter().ShoesColor);
    }
}
