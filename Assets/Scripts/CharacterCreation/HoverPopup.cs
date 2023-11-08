using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HoverPopup : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI _headerWhite;
    [SerializeField] private TextMeshProUGUI _headerShadow;
    [SerializeField] private TextMeshProUGUI _body;

    [Header("Melee Class Texts")]
    [SerializeField] private string _brawlerText;
    [SerializeField] private string _warriorText;
    [SerializeField] private string _rogueText;
    [SerializeField] private string _paladinText;
    [SerializeField] private string _berserkerText;
    [SerializeField] private string _protectorText;
    [SerializeField] private string _executionerText;

    [Header("Ranged Class Texts")]
    [SerializeField] private string _marksmanText;
    [SerializeField] private string _hunterText;
    [SerializeField] private string _tinkererText;
    [SerializeField] private string _deadeyeText;
    [SerializeField] private string _vigilanteText;
    [SerializeField] private string _axeHurlerText;
    [SerializeField] private string _SwashbucklerText;

    [Header("Magic Class Texts")]
    [SerializeField] private string _wizardText;
    [SerializeField] private string _healerText;
    [SerializeField] private string _necromancerText;
    [SerializeField] private string _mediumText;
    [SerializeField] private string _illusionistText;
    [SerializeField] private string _druidText;
    [SerializeField] private string _shapeshifterText;

    private void Update()
    {
        // set position to mouse position
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }

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

    public void SurveyErrorPopup(Button button)
    {
        if(!button.interactable)
        {
            SetHeader("Unable to Submit");
            SetBody("You must answer all survey questions before you can submit");
            EnablePopup();
        }
    }

    public void FinalizeErrorPopup(Button button)
    {
        if (!button.interactable)
        {
            SetHeader("Unable to Submit");
            SetBody("You must select a class before you can finalize");
            EnablePopup();
        }
    }

    public void DisablePopup()
    {
        gameObject.SetActive(false);
    }

    public void ClassPopup(int buttonIndex)
    {
        string className = ButtonFunctionHelper.CalculateClassOptions()[buttonIndex];
        switch(className)
        {
            case "Brawler":
                SetHeader("Brawler");
                SetBody(_brawlerText);
                EnablePopup();
                break;
            case "Warrior":
                SetHeader("Warrior");
                SetBody(_warriorText);
                EnablePopup();
                break;
            case "Rogue":
                SetHeader("Rogue");
                SetBody(_rogueText);
                EnablePopup();
                break;
            case "Paladin":
                SetHeader("Paladin");
                SetBody(_paladinText);
                EnablePopup();
                break;
            case "Berserker":
                SetHeader("Berserker");
                SetBody(_berserkerText);
                EnablePopup();
                break;
            case "Protector":
                SetHeader("Protector");
                SetBody(_protectorText);
                EnablePopup();
                break;
            case "Executioner":
                SetHeader("Executioner");
                SetBody(_executionerText);
                EnablePopup();
                break;
            case "Hunter":
                SetHeader("Hunter");
                SetBody(_hunterText);
                EnablePopup();
                break;
            case "Tinkerer":
                SetHeader("Tinkerer");
                SetBody(_tinkererText);
                EnablePopup();
                break;
            case "Deadeye":
                SetHeader("Deadeye");
                SetBody(_deadeyeText);
                EnablePopup();
                break;
            case "Vigilante":
                SetHeader("Vigilante");
                SetBody(_vigilanteText);
                EnablePopup();
                break;
            case "Axe Hurler":
                SetHeader("Axe Hurler");
                SetBody(_axeHurlerText);
                EnablePopup();
                break;
            case "Swashbuckler":
                SetHeader("Swashbuckler");
                SetBody(_SwashbucklerText);
                EnablePopup();
                break;
            case "Wizard":
                SetHeader("Wizard");
                SetBody(_wizardText);
                EnablePopup();
                break;
            case "Healer":
                SetHeader("Healer");
                SetBody(_healerText);
                EnablePopup();
                break;
            case "Necromancer":
                SetHeader("Necromancer");
                SetBody(_necromancerText);
                EnablePopup();
                break;
            case "Medium":
                SetHeader("Medium");
                SetBody(_mediumText);
                EnablePopup();
                break;
            case "Illusionist":
                SetHeader("Illusionist");
                SetBody(_illusionistText);
                EnablePopup();
                break;
            case "Druid":
                SetHeader("Druid");
                SetBody(_druidText);
                EnablePopup();
                break;
            case "Shapeshifter":
                SetHeader("Shapeshifter");
                SetBody(_shapeshifterText);
                EnablePopup();
                break;
            case "Marksman":
                SetHeader("Marksman");
                SetBody(_marksmanText);
                EnablePopup();
                break;
        }
    }
}
