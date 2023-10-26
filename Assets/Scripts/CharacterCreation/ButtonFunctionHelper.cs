using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Extras;
using UnityEngine.SceneManagement;

public class ButtonFunctionHelper : MonoBehaviour
{
    #region SCENE TRANSITIONS

    private const int SELECT_SCENE_INDEX = 1;
    private const int PLAY_SCENE_INDEX = 3;
    private bool play = false;

    private ScreenTransition _screenTransition;
    private PanelController deleteScreen;
    private PanelController submitScreen;
    private PanelController finalizeScreen;
    [SerializeField] private FadeUI raycastBlocker;

    private void Start()
    {
        _screenTransition = FindObjectOfType<ScreenTransition>();
        deleteScreen = GameObject.Find("Confirm Delete Panel").GetComponent<PanelController>();
        submitScreen = GameObject.Find("Confirm Submit").GetComponent<PanelController>();
        finalizeScreen = GameObject.Find("Confirm Finalize").GetComponent<PanelController>();
        raycastBlocker.gameObject.SetActive(false);
    }

    public void DeleteButton()  // Calls down the delete confirmation window
    {
        deleteScreen.ShowPanel();
        raycastBlocker.gameObject.SetActive(true);
        raycastBlocker.UIFadeIn();
    }

    public void DeleteConfirmButton() // Goes back to character select - deletes character
    {
        StopAllCoroutines();
        StartCoroutine(DoEviscerate());
    }

    public void DeleteDenialButton()    // Backs the delete window down, keeps character intact
    {
        deleteScreen.HidePanel();
        raycastBlocker.UIFadeOut();
    }

    public void PlayButton()
    {
        play = true;
        finalizeScreen.ShowPanel();
        raycastBlocker.gameObject.SetActive(true);
        raycastBlocker.UIFadeIn();
    }

    public void BackToSelectButton()
    {
        play = false;
        finalizeScreen.ShowPanel();
        raycastBlocker.gameObject.SetActive(true);
        raycastBlocker.UIFadeIn();
    }


    public void ConfirmLeaveButton() // Goes back to character select - saves character
    {
        StopAllCoroutines();
        StartCoroutine(DoLeaveScene(play));
    }

    public void RejectLeaveButton()
    {
        finalizeScreen.HidePanel();
        raycastBlocker.UIFadeOut();
    }

    // Coroutines
    private IEnumerator DoEviscerate()
    {
        _screenTransition.GoToPrevScene();
        yield return new WaitForSeconds(1f);
        // Delete current selected character's data
        GameManager.Instance.RemoveCurrentCharacter();
        // load new scene
        SceneManager.LoadScene(SELECT_SCENE_INDEX);
    }

    /*private IEnumerator DoBack()
    {
        _screenTransition.GoToPrevScene();
        yield return new WaitForSeconds(1f);
        // load new scene
        SceneManager.LoadScene(SELECT_SCENE_INDEX);
    }

    private IEnumerator DoPlay()
    {
        _screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);
        // load new scene
        SceneManager.LoadScene(PLAY_SCENE_INDEX);
    }*/

    private IEnumerator DoLeaveScene(bool play)
    {
        if (play)
        {
            _screenTransition.GoToNextScene();
            yield return new WaitForSeconds(1f);
            // load new scene
            SceneManager.LoadScene(PLAY_SCENE_INDEX);
        }
        else
        {
            _screenTransition.GoToPrevScene();
            yield return new WaitForSeconds(1f);
            // load new scene
            SceneManager.LoadScene(SELECT_SCENE_INDEX);
        }
    }

    #endregion

    #region STEP 1: APPEARANCE

    #region APPEARANCE: randomize
    // constants
    private const int NUM_ARCHETYPES = 3;
    private const int NUM_TOGGLES_STD = 5;
    private const int NUM_TOGGLES_SHIRT = 6;

    // required for updating toggles after randomizing
    [Header("Toggles")]
    [SerializeField] Toggle[] ArchetypeToggles = new Toggle[NUM_ARCHETYPES];
    [SerializeField] Toggle[] HairToggles = new Toggle[NUM_TOGGLES_STD];
    [SerializeField] Toggle[] FaceToggles = new Toggle[NUM_TOGGLES_STD];
    [SerializeField] Toggle[] ShirtToggles = new Toggle[NUM_TOGGLES_SHIRT];
    [SerializeField] Toggle[] PantsToggles = new Toggle[NUM_TOGGLES_STD];
    [SerializeField] Toggle[] ShoesToggles = new Toggle[NUM_TOGGLES_STD];

    // Randomize button
    public void Randomize()
    {
        int rand;

        // class
        rand = Random.Range(0, 3);
        GameManager.Instance.GetCharacter().Archetype = rand;
        ArchetypeToggles[rand].SetIsOnWithoutNotify(true);

        // Hair
        rand = Random.Range(0, 6);
        GameManager.Instance.GetCharacter().HairType = rand;
        if (rand > 0)
            HairToggles[rand - 1].SetIsOnWithoutNotify(true);
        else
            HairToggles[0].group.SetAllTogglesOff();

        // Face
        rand = Random.Range(0, 6);
        GameManager.Instance.GetCharacter().FaceType = rand;
        if (rand > 0)
            FaceToggles[rand - 1].SetIsOnWithoutNotify(true);
        else
            FaceToggles[0].group.SetAllTogglesOff();

        // Shirt
        rand = Random.Range(0, 7);
        GameManager.Instance.GetCharacter().ShirtType = rand;
        if (rand > 0)
            ShirtToggles[rand - 1].SetIsOnWithoutNotify(true);
        else
            ShirtToggles[0].group.SetAllTogglesOff();

        // Pants
        if (rand == 6) // disable pants if robe is equipped as shirt
        {
            GameManager.Instance.GetCharacter().PantsType = 0;
            PantsToggles[0].group.SetAllTogglesOff();
        }
        else // robe not equipped
        {
            rand = Random.Range(0, 6);
            GameManager.Instance.GetCharacter().PantsType = rand;
            if (rand > 0)
                PantsToggles[rand - 1].SetIsOnWithoutNotify(true);
            else
                PantsToggles[0].group.SetAllTogglesOff();
        }

        // Shoes
        rand = Random.Range(0, 6);
        GameManager.Instance.GetCharacter().ShoesType = rand;
        if (rand > 0)
            ShoesToggles[rand - 1].SetIsOnWithoutNotify(true);
        else
            ShoesToggles[0].group.SetAllTogglesOff();

        // colors
        GameManager.Instance.GetCharacter().SkinColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().HairColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().ShirtColor1 = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().ShirtColor2 = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().PantsColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        GameManager.Instance.GetCharacter().ShoesColor = HelperFunctions.ColorToInt(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }
    #endregion

    #region APPEARANCE: setters
    // Update text
    public void UpdateName(TMP_InputField name) {
        if (name.text.Length > 0) GameManager.Instance.GetCharacter().Name = "~ " + name.text + " ~";
        else GameManager.Instance.GetCharacter().Name = "~ Nameless ~";
    }

    public void SetArchetype(int archetypeIndex) 
    { 
        GameManager.Instance.GetCharacter().Archetype = archetypeIndex;
        GameManager.Instance.GetCharacter().Class = ""; // reset class if archetype changes (shouldn't be needed in practice)
    }

    // Setters
    public void SetHair(int val) { GameManager.Instance.GetCharacter().HairType = val; }

    public void SetFace(int val) { GameManager.Instance.GetCharacter().FaceType = val; }

    public void SetShirt(int val) { GameManager.Instance.GetCharacter().ShirtType = val; }

    public void SetPants(int val) { GameManager.Instance.GetCharacter().PantsType = val; }

    public void SetShoes(int val) { GameManager.Instance.GetCharacter().ShoesType = val; }
    #endregion

    #region APPEARANCE: button untoggling checks
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
    #endregion

    #region APPEARANCE: color picker buttons
    // Color picking
    [Header("Color Picking")]
    [SerializeField] private ColorPickerInputHandler _colorPicker;
    [SerializeField] private GameObject _closeColorPickerButton;

    public void EnableColorPicker(int colorIndex)
    {
        if(_colorPicker.GetColorIndex() != colorIndex || !_colorPicker.gameObject.activeSelf) // open new color picker window
        {
            // activate color picker
            _colorPicker.gameObject.SetActive(true);
            _colorPicker.OpenNewPicker(colorIndex);

            // set position of color picker
            RectTransform rect = _colorPicker.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(rect.localPosition.x, 
                _colorPicker.GetComponent<ColorPickerPositionData>().GetYPos(colorIndex), rect.localPosition.z);

            // activate button overlay to close color picker
            _closeColorPickerButton.SetActive(true);
        }
    }

    public void DisableColorPicker()
    {
        // disable color picker and close color picker button
        _colorPicker.gameObject.SetActive(false);
        _closeColorPickerButton.SetActive(false);
    }
    #endregion

    #endregion

    #region STEP 2: PERSONALITY

    private float[] answers = new float[15];

    public void Answer1(float val) { answers[0] = val; }
    public void Answer2(float val) { answers[1] = val; }
    public void Answer3(float val) { answers[2] = val; }
    public void Answer4(float val) { answers[3] = val; }
    public void Answer5(float val) { answers[4] = val; }
    public void Answer6(float val) { answers[5] = val; }
    public void Answer7(float val) { answers[6] = val; }
    public void Answer8(float val) { answers[7] = -val; }
    public void Answer9(float val) { answers[8] = val; }
    public void Answer10(float val) { answers[9] = val; }
    public void Answer11(float val) { answers[10] = val; }
    public void Answer12(float val) { answers[11] = val; }
    public void Answer13(float val) { answers[12] = val; }
    public void Answer14(float val) { answers[13] = -val; }
    public void Answer15(float val) { answers[14] = -val; }

    public void Submit()
    {
        // Courage to Caution
        float courageCaution = answers[0] + answers[6] + answers[12];
        GameManager.Instance.GetCharacter().CourageToCaution = 0.5f - courageCaution;

        // Honesty to Deception
        float honestyDeception = answers[1] + answers[7] + answers[13];
        GameManager.Instance.GetCharacter().HonestyToDeception = 0.5f - honestyDeception;

        // Diplomacy to Aggression
        float diplomacyAggression = answers[2] + answers[8];
        GameManager.Instance.GetCharacter().DiplomacyToAggression = 0.5f - diplomacyAggression;

        // Empathy to Ruthlessness
        float empathyRuthlessness = answers[3] + answers[9];
        GameManager.Instance.GetCharacter().EmpathyToRuthlessness = 0.5f - empathyRuthlessness;

        // Optimism to Pessimism
        float optimismPessimism = answers[4] + answers[10];
        GameManager.Instance.GetCharacter().OptimismToPessimism = 0.5f - optimismPessimism;

        // Mysticism to Skepticism
        float mysticismSkepticism = answers[5] + answers[11] + answers[14];
        GameManager.Instance.GetCharacter().MysticismToSkepticism = 0.5f - mysticismSkepticism;
    }
    #endregion

    #region STEP 3: FINALIZE / CLASS SELECTION

    // constants
    private const float GENERALIST_CUTOFF = 0.25f;

    /// <summary>
    /// Updates class string in save data
    /// </summary>
    /// <param name="buttonIndex">index of class option button (0 to 2)</param>
    public void SetClass(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex <= 2)
            GameManager.Instance.GetCharacter().Class = CalculateClassOptions()[buttonIndex];
        else
            Debug.LogError("SetClass(buttonIndex): invalid buttonIndex (must be 0, 1, or 2)");
    }

    // clear class on untoggle
    public void CheckUntoggleClass(ToggleGroup group) { if (!group.AnyTogglesOn()) GameManager.Instance.GetCharacter().Class = ""; }

    /// <summary>
    /// returns ordered list of string classes determined by personality distribution
    /// </summary>
    public static string[] CalculateClassOptions()
    {
        string[] classOptions = new string[3];
        CharacterData character = GameManager.Instance.GetCharacter();

        int[] maxMidMinIndices; // used to determine priority ordering of three class pairs
        float minMagnitude; // needed to check for generalist case
        switch (character.Archetype)
        {
            case 0: // melee
                // calculate scales for each class pair
                float warriorToRogue = character.CourageToCaution + character.HonestyToDeception - 1.0f;
                float paladinToBerserker = character.DiplomacyToAggression + character.MysticismToSkepticism - 1.0f;
                float protectorToExecutioner = character.EmpathyToRuthlessness + character.OptimismToPessimism - 1.0f;
                // Other calculations
                maxMidMinIndices = CalculateOrderedIndices(warriorToRogue, paladinToBerserker, protectorToExecutioner);
                minMagnitude = Mathf.Min(Mathf.Abs(warriorToRogue), Mathf.Abs(paladinToBerserker), Mathf.Abs(protectorToExecutioner));

                // generate strings from calculated max/mid/min indexes and signs
                for (int index = 0; index < 3; index++)
                {
                    switch(maxMidMinIndices[index])
                    {
                        case 0:
                            if (warriorToRogue < 0) classOptions[index] = "Warrior";
                            else classOptions[index] = "Rogue";
                            break;
                        case 1:
                            if (paladinToBerserker < 0) classOptions[index] = "Paladin";
                            else classOptions[index] = "Berserker";
                            break;
                        case 2:
                            if (protectorToExecutioner < 0) classOptions[index] = "Protector";
                            else classOptions[index] = "Executioner";
                            break;
                    }
                }
                // check for generalist case
                if (minMagnitude < GENERALIST_CUTOFF) classOptions[2] = "Brawler";

                break;
            case 1: // ranged
                // calculate scales for each class pair
                float axeHurlerToHunter = character.CourageToCaution + (1.0f - character.DiplomacyToAggression) - 1.0f;
                float vigilanteToDeadeye = character.HonestyToDeception + character.OptimismToPessimism - 1.0f;
                float swashbucklerToTinkerer = character.MysticismToSkepticism + (1.0f - character.EmpathyToRuthlessness) - 1.0f;
                // Other calculations
                maxMidMinIndices = CalculateOrderedIndices(axeHurlerToHunter, vigilanteToDeadeye, swashbucklerToTinkerer);
                minMagnitude = Mathf.Min(Mathf.Abs(axeHurlerToHunter), Mathf.Abs(vigilanteToDeadeye), Mathf.Abs(swashbucklerToTinkerer));

                // generate strings from calculated max/mid/min indexes and signs
                for (int index = 0; index < 3; index++)
                {
                    switch (maxMidMinIndices[index])
                    {
                        case 0:
                            if (axeHurlerToHunter < 0) classOptions[index] = "Axe Hurler";
                            else classOptions[index] = "Hunter";
                            break;
                        case 1:
                            if (vigilanteToDeadeye < 0) classOptions[index] = "Vigilante";
                            else classOptions[index] = "Deadeye";
                            break;
                        case 2:
                            if (swashbucklerToTinkerer < 0) classOptions[index] = "Swashbuckler";
                            else classOptions[index] = "Tinkerer";
                            break;
                    }
                }
                // check for generalist case
                if (minMagnitude < GENERALIST_CUTOFF) classOptions[2] = "Marksman";

                break;
            case 2: // magic
                // calculate scales for each class pair
                float shapeshifterToDruid = character.CourageToCaution + (1.0f - character.HonestyToDeception) - 1.0f;
                float mediumToIllusionist = character.DiplomacyToAggression + character.MysticismToSkepticism - 1.0f;
                float healerToNecromancer = character.EmpathyToRuthlessness + character.OptimismToPessimism - 1.0f;
                // Other calculations
                maxMidMinIndices = CalculateOrderedIndices(shapeshifterToDruid, mediumToIllusionist, healerToNecromancer);
                minMagnitude = Mathf.Min(Mathf.Abs(shapeshifterToDruid), Mathf.Abs(mediumToIllusionist), Mathf.Abs(healerToNecromancer));

                // generate strings from calculated max/mid/min indexes and signs
                for (int index = 0; index < 3; index++)
                {
                    switch (maxMidMinIndices[index])
                    {
                        case 0:
                            if (shapeshifterToDruid < 0) classOptions[index] = "Shapeshifter";
                            else classOptions[index] = "Druid";
                            break;
                        case 1:
                            if (mediumToIllusionist < 0) classOptions[index] = "Medium";
                            else classOptions[index] = "Illusionist";
                            break;
                        case 2:
                            if (healerToNecromancer < 0) classOptions[index] = "Healer";
                            else classOptions[index] = "Necromancer";
                            break;
                    }
                }
                // check for generalist case
                if (minMagnitude < GENERALIST_CUTOFF) classOptions[2] = "Wizard";

                break;
            default: // error
                Debug.LogError("CalculateClassOptions(): invalid archetype ID");
                break;
        }

        return classOptions;

        // generates ordering of indices for three value scales
        int[] CalculateOrderedIndices(float val0, float val1, float val2)
        {
            // determine BEST match
            int maxIndex;
            float maxMagnitude = Mathf.Max(Mathf.Abs(val0), Mathf.Abs(val1), Mathf.Abs(val2));
            if (maxMagnitude == Mathf.Abs(val0)) maxIndex = 0;
            else if (maxMagnitude == Mathf.Abs(val1)) maxIndex = 1;
            else maxIndex = 2; // third option max

            // determine WORST/MIDDLE match - ensure no duplicate in case of ties
            int midIndex;
            int minIndex;
            float minMagnitude = Mathf.Min(Mathf.Abs(val0), Mathf.Abs(val1), Mathf.Abs(val2));
            if (minMagnitude == Mathf.Abs(val0))
            {
                minIndex = 0;
                midIndex = maxIndex == 1 ? 2 : 1; // mid is the one neither min or max are
            }
            else if (minMagnitude == Mathf.Abs(val1))
            {
                minIndex = 1;
                midIndex = maxIndex == 0 ? 2 : 0; // mid is the one neither min or max are
            }
            else // third option min
            {
                minIndex = 2;
                midIndex = maxIndex == 0 ? 1 : 0; // mid is the one neither min or max are
            }

            if (maxIndex == minIndex) // min == max -> ensure no duplicate in the case of three-way tie
            {
                // arbitrary assignment to prevent duplicates
                maxIndex = 0;
                midIndex = 1;
                minIndex = 2;
            }

            return new int[] {maxIndex, midIndex, minIndex };
        }
    }

    #endregion

    #region STEP NAVIGATION

    [Header("Step Navigation")]
    [SerializeField] private GameObject _step1;
    [SerializeField] private GameObject _step2;
    [SerializeField] private GameObject _step3;

    /// <summary>
    /// enable appropriate step and disable all others
    /// </summary>
    /// <param name="screenIndex">between 1 and 3 (step number)</param>
    public void LoadStepScreen(int screenIndex)
    {
        switch(screenIndex)
        {
            case 1:
                _step1.SetActive(true);
                _step2.SetActive(false);
                _step3.SetActive(false);
                break;
            case 2:
                _step1.SetActive(false);
                _step2.SetActive(true);
                _step3.SetActive(false);
                break;
            case 3:
                submitScreen.ShowPanel();
                raycastBlocker.gameObject.SetActive(true);
                raycastBlocker.UIFadeIn();
                break;
            default:
                Debug.LogError("LoadStepScreen(screenIndex): Invalid screenIndex");
                break;
        }
    }

    public void ConfirmSubmit()
    {
        _step1.SetActive(false);
        _step2.SetActive(false);
        _step3.SetActive(true);
        Submit();
        submitScreen.HidePanel();
        raycastBlocker.UIFadeOut();
    }

    public void RejectSubmit()
    {
        submitScreen.HidePanel();
        raycastBlocker.UIFadeOut();
    }

    #endregion
}
