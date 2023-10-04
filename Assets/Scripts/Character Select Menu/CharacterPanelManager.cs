using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private GameObject newButtonPrefab;
    [SerializeField] private Transform parentCanvas;

    private bool loaded = false;

    // Start is called before the first frame update
    void Start()
    {
        loaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!loaded)
        {
            StartCoroutine(DoSpawnPanels());
            loaded = true;
        }
    }

    private IEnumerator DoSpawnPanels()
    {
        int onScreenCount = GameManager.Instance.GetCharacterCount(); // A running tally of how many character panels are currently displayed

        Debug.Log(GameManager.Instance.GetCharacterCount());
        for (int i = 0; i < GameManager.Instance.GetCharacterCount(); i++) // While we can still get characters
        {
            GameManager.Instance.SetSelectedCharacterIndex(i);   // Sets the appropriate index for getting the next character
            GameObject charaPanel = Instantiate(panelPrefab, new Vector3(spawnpoints[i].position.x, spawnpoints[i].position.y, spawnpoints[i].position.z), Quaternion.Euler(Vector3.zero), parentCanvas);   // Create the panel at the right position
            yield return new WaitForSeconds(.1f);                                           // While useful as a visual effect as well, a slight delay is actually necessary for the character display to update
            charaPanel.GetComponent<CharacterPanel>().SetValues(i);             // Give that panel the correct index for potential data retrieval
        }

        if(onScreenCount < 8) // If we have made less than 8 characters, spawn in the "make a new one" button
        {
            GameObject newCharaButton = Instantiate(newButtonPrefab, new Vector3(spawnpoints[onScreenCount].position.x, spawnpoints[onScreenCount].position.y, spawnpoints[onScreenCount].position.z), Quaternion.Euler(Vector3.zero), parentCanvas);    // Create the panel at the right position
        }

    }
}
