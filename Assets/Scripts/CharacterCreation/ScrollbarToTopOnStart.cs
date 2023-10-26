using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarToTopOnStart : MonoBehaviour
{
    private const float TOP_VALUE = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Scrollbar>().value = TOP_VALUE;
    }
}
