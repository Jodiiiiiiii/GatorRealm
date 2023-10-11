using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerPositionData : MonoBehaviour
{
    private const int NUM_PICKERS = 6;

    [SerializeField] private float[] yPositions = new float[NUM_PICKERS];

    public float GetYPos(int index)
    {
        if (index >= 0 && index < NUM_PICKERS)
            return yPositions[index];

        // invalid index
        Debug.LogError("Invalid color picker index - out of bounds");
        return float.NaN;
    }
}
