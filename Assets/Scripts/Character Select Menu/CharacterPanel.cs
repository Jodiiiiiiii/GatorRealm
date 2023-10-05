using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    private int arrayIndex; // Held within each panel so that the current index can be changed when the panel is selected

    public CharacterPanel(int arrayIndex) // Constructor
    {
        this.arrayIndex = arrayIndex;
    }

    public void SetValues(int arrayIndex)
    {
        this.arrayIndex = arrayIndex;
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
