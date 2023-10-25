using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequireToggleGroupsToPress : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button _button;

    [Header("Toggle Groups")]
    [SerializeField] private List<ToggleGroup> _toggleGroups;

    private void Start()
    {
        // set initial state properly - should be just not interactable in all cases for this project
        CheckForAllTogglesSelected();
    }

    public void CheckForAllTogglesSelected()
    {
        bool allSelected = true;
        foreach (ToggleGroup group in _toggleGroups)
            if (!group.AnyTogglesOn()) allSelected = false;

        _button.interactable = allSelected;
    }
}
