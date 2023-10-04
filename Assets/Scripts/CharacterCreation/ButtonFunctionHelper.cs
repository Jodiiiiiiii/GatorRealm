using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Extras;

public class ButtonFunctionHelper : MonoBehaviour
{
    #region STEP 1: APPEARANCE
    // Randomize button
    public void Randomize()
    {
        // class
        int rand = Random.Range(0, 4);
        if (rand == 0)
            GameManager.Instance.GetCharacter().Class = "~ Generalist Archetype ~";
        else if(rand == 1)
            GameManager.Instance.GetCharacter().Class = "~ Melee Archetype ~";
        else if(rand == 2)
            GameManager.Instance.GetCharacter().Class = "~ Ranged Archetype ~";
        else
            GameManager.Instance.GetCharacter().Class = "~ Magic Archetype ~";

        // cosmetics
        GameManager.Instance.GetCharacter().HairType = Random.Range(0, 6);
        GameManager.Instance.GetCharacter().FaceType = Random.Range(0, 6);
        GameManager.Instance.GetCharacter().ShirtType = Random.Range(0, 7);
        if (GameManager.Instance.GetCharacter().ShirtType == 6)
            GameManager.Instance.GetCharacter().PantsType = 0;
        else
            GameManager.Instance.GetCharacter().PantsType = Random.Range(0, 6);
        GameManager.Instance.GetCharacter().ShoesType = Random.Range(0, 6);

        // colors
        GameManager.Instance.GetCharacter().SkinColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().HairColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().ShirtColor1 = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().ShirtColor2 = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().PantsColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().ShoesColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

    // Update text
    public void UpdateName(TMP_InputField name) {
        if (name.text.Length > 0) GameManager.Instance.GetCharacter().Name = "~ " + name.text + " ~";
        else GameManager.Instance.GetCharacter().Name = "~ Nameless ~";
    }
    public void UpdateClass(string classText) { GameManager.Instance.GetCharacter().Class = classText; }

    // Setters
    public void SetHair(int val) { GameManager.Instance.GetCharacter().HairType = val; }

    public void SetFace(int val) { GameManager.Instance.GetCharacter().FaceType = val; }

    public void SetShirt(int val) { GameManager.Instance.GetCharacter().ShirtType = val; }

    public void SetPants(int val) { GameManager.Instance.GetCharacter().PantsType = val; }

    public void SetShoes(int val) { GameManager.Instance.GetCharacter().ShoesType = val; }

    // Untoggling
    public void CheckHairUntoggle(ToggleGroup group) { if (!group.AnyTogglesOn()) GameManager.Instance.GetCharacter().HairType = 0; }
    public void CheckFaceUntoggle(ToggleGroup group) { if (!group.AnyTogglesOn()) GameManager.Instance.GetCharacter().FaceType = 0; }
    public void CheckShirtUntoggle(ToggleGroup group) { if (!group.AnyTogglesOn()) GameManager.Instance.GetCharacter().ShirtType = 0; }
    public void CheckPantsUntoggle(ToggleGroup group) { if (!group.AnyTogglesOn()) GameManager.Instance.GetCharacter().PantsType = 0; }
    public void CheckShoesUntoggle(ToggleGroup group) { if (!group.AnyTogglesOn()) GameManager.Instance.GetCharacter().ShoesType = 0; }

    // Robe button handling
    // resets toggle given group - used to disable pants when robe selected
    public void DisablePantsToggleGroup(ToggleGroup pantsGroup)
    {
        Toggle toggleToDisable = pantsGroup.GetFirstActiveToggle();
        if (toggleToDisable != null)
        {
            toggleToDisable.SetIsOnWithoutNotify(false); // remove selected state of pants button
            GameManager.Instance.GetCharacter().PantsType = 0; // remove pants visually
        }
    }

    // remogves robe as shirt if any pants are selected
    public void RemoveShirtIfRobe(ToggleGroup shirtGroup)
    {
        Toggle robeToggle = shirtGroup.GetFirstActiveToggle();
        if (robeToggle != null && robeToggle.name == "Robe Toggle")
        {
            robeToggle.SetIsOnWithoutNotify(false); // removes selected state of robe button
            GameManager.Instance.GetCharacter().ShirtType = 0; // removes robe visibly
        }
    }

    // Color picking
    [SerializeField] private ColorPickerInputHandler _colorPicker;

    public void ColorPickerToggle(int colorIndex)
    {
        if(_colorPicker.GetColorIndex() != colorIndex || !_colorPicker.gameObject.activeSelf) // open new color picker window
        {
            _colorPicker.gameObject.SetActive(true);
            _colorPicker.OpenNewPicker(colorIndex);

            // add something here about setting position of color picker
        }
        else // close current color picker tab
        {
            _colorPicker.OpenNewPicker(-1); // set to none selected state
            _colorPicker.gameObject.SetActive(false);
        }
    }
    #endregion
}
