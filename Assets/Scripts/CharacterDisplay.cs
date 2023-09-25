using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
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
        // COLOR DATA NOT IMPLEMENTED
    }
}
