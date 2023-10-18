using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetClassOptionImages : MonoBehaviour
{

    [Header("Image Components")]
    [SerializeField] private Image[] _images = new Image[3];

    [Header("Sprite Icons - Melee")]
    [SerializeField] private Sprite _brawler;
    [SerializeField] private Sprite _warrior;
    [SerializeField] private Sprite _rogue;
    [SerializeField] private Sprite _paladin;
    [SerializeField] private Sprite _berserker;
    [SerializeField] private Sprite _protector;
    [SerializeField] private Sprite _executioner;

    [Header("Sprite Icons - Ranged")]
    [SerializeField] private Sprite _marksman;
    [SerializeField] private Sprite _hunter;
    [SerializeField] private Sprite _tinkerer;
    [SerializeField] private Sprite _deadeye;
    [SerializeField] private Sprite _vigilante;
    [SerializeField] private Sprite _axeHurler;
    [SerializeField] private Sprite _swashbuckler;

    [Header("Sprite Icons - Magic")]
    [SerializeField] private Sprite _wizard;
    [SerializeField] private Sprite _healer;
    [SerializeField] private Sprite _necromancer;
    [SerializeField] private Sprite _medium;
    [SerializeField] private Sprite _illusionist;
    [SerializeField] private Sprite _druid;
    [SerializeField] private Sprite _shapeshifter;

    // Update is called once per frame
    void Update()
    {
        string[] classOptions = ButtonFunctionHelper.CalculateClassOptions();

        for(int index = 0; index < 3; index++)
        {
            switch(classOptions[index])
            {
                case "Brawler":
                    _images[index].sprite = _brawler;
                    break;
                case "Warrior":
                    _images[index].sprite = _warrior;
                    break;
                case "Rogue":
                    _images[index].sprite = _rogue;
                    break;
                case "Paladin":
                    _images[index].sprite = _paladin;
                    break;
                case "Berserker":
                    _images[index].sprite = _berserker;
                    break;
                case "Protector":
                    _images[index].sprite = _protector;
                    break;
                case "Executioner":
                    _images[index].sprite = _executioner;
                    break;
                case "Marksman":
                    _images[index].sprite = _marksman;
                    break;
                case "Hunter":
                    _images[index].sprite = _hunter;
                    break;
                case "Tinkerer":
                    _images[index].sprite = _tinkerer;
                    break;
                case "Deadeye":
                    _images[index].sprite = _deadeye;
                    break;
                case "Vigilante":
                    _images[index].sprite = _vigilante;
                    break;
                case "Axe Hurler":
                    _images[index].sprite = _axeHurler;
                    break;
                case "Swashbuckler":
                    _images[index].sprite = _swashbuckler;
                    break;
                case "Wizard":
                    _images[index].sprite = _wizard;
                    break;
                case "Healer":
                    _images[index].sprite = _healer;
                    break;
                case "Necromancer":
                    _images[index].sprite = _necromancer;
                    break;
                case "Medium":
                    _images[index].sprite = _medium;
                    break;
                case "Illusionist":
                    _images[index].sprite = _illusionist;
                    break;
                case "Druid":
                    _images[index].sprite = _druid;
                    break;
                case "Shapeshifter":
                    _images[index].sprite = _shapeshifter;
                    break;
            }
        }
    }
}
