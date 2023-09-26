using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectButtons : MonoBehaviour
{
    public void BackButton()
    {
        //TODO: Add screen transition effect
        SceneManager.LoadScene(0);
    }

    public void NewCharaButton()
    {
        //TODO: Add screen transition effect
        SceneManager.LoadScene(2);
    }
}
