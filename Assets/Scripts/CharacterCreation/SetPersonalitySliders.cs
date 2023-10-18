using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPersonalitySliders : MonoBehaviour
{
    [Header("Slider Components")]
    [SerializeField] private Slider _courageToCaution;
    [SerializeField] private Slider _honestyToDeception;
    [SerializeField] private Slider _diplomacyToAggression;
    [SerializeField] private Slider _empathyToRuthlessness;
    [SerializeField] private Slider _optimismToPessimism;

    // Update is called once per frame
    void Update()
    {
        // read values from game manager
        _courageToCaution.value = GameManager.Instance.GetCharacter().CourageToCaution;
        _honestyToDeception.value = GameManager.Instance.GetCharacter().HonestyToDeception;
        _diplomacyToAggression.value = GameManager.Instance.GetCharacter().DiplomacyToAggression;
        _empathyToRuthlessness.value = GameManager.Instance.GetCharacter().EmpathyToRuthlessness;
        _optimismToPessimism.value = GameManager.Instance.GetCharacter().OptimismToPessimism;
    }
}
