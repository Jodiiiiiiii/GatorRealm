using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonFunctionHelper : MonoBehaviour
{
    #region STEP 1: APPEARANCE
    // Update text
    public void UpdateName(TMP_InputField name) {
        if (name.text.Length > 0) GameManager.Instance.GetCharacter().Name = "~ " + name.text + " ~";
        else GameManager.Instance.GetCharacter().Name = "~ Nameless ~";
    }
    public void UpdateClass(string classText) { GameManager.Instance.GetCharacter().Class = classText; }

    // Untoggling Class
    public void CheckClassUntoggle(ToggleGroup group) { if(!group.AnyTogglesOn()) GameManager.Instance.GetCharacter().Class = "~ Generalist Archetype ~"; }

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
    public void Answer8(float val) { answers[7] = val; }
    public void Answer9(float val) { answers[8] = val; }
    public void Answer10(float val) { answers[9] = val; }
    public void Answer11(float val) { answers[10] = val; }
    public void Answer12(float val) { answers[11] = val; }
    public void Answer13(float val) { answers[12] = val; }
    public void Answer14(float val) { answers[13] = val; }
    public void Answer15(float val) { answers[14] = val; }

    public void Submit(){
        // Courage to Caution
        float courageCaution = answers[0] + answers[6] + answers[12];
        GameManager.Instance.GetCharacter().CourageToCaution = 0.5f + courageCaution;

        // Honesty to Deception
        float honestyDeception = answers[1] + answers[7] + answers[13];
        GameManager.Instance.GetCharacter().HonestyToDeception = 0.5f + honestyDeception;

        // Diplomacy to Aggression
        float diplomacyAggression = answers[2] + answers[8];
        GameManager.Instance.GetCharacter().DiplomacyToAggression = 0.5f + diplomacyAggression;

        // Empathy to Ruthlessness
        float empathyRuthlessness = answers[3] + answers[9];
        GameManager.Instance.GetCharacter().EmpathyToRuthlessness = 0.5f + empathyRuthlessness;

        // Optimism to Pessimism
        float optimismPessimism = answers[4] + answers[10];
        GameManager.Instance.GetCharacter().OptimismToPessimism = 0.5f + optimismPessimism;

        // Mysticism to Skepticism
        float mysticismSkepticism = answers[5] + answers[11] + answers[14];
        GameManager.Instance.GetCharacter().MysticismToSkepticism = 0.5f + mysticismSkepticism;

    }

    #endregion
}
