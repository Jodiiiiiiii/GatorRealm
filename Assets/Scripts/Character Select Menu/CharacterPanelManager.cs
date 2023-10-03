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
        int onScreenCount = 0; // A running tally of how many character panels are currently displayed
        GameManager.Instance.SetCurrentCharacterIndex(onScreenCount);

        while (GameManager.Instance.GetCharacter() != null) // While we can still get characters
        {             
            GameObject charaPanel = Instantiate(panelPrefab, new Vector3(spawnpoints[onScreenCount].position.x, spawnpoints[onScreenCount].position.y, spawnpoints[onScreenCount].position.z), Quaternion.Euler(Vector3.zero), parentCanvas);   // Create the panel at the right position
            yield return new WaitForSeconds(.1f);                                           // While useful as a visual effect as well, a slight delay is actually necessary for the character display to update
            charaPanel.GetComponent<CharacterPanel>().SetValues(onScreenCount);             // Give that panel the correct index for potential data retrieval
            onScreenCount++;
            GameManager.Instance.SetCurrentCharacterIndex(onScreenCount);   // Sets the appropriate index for getting the next character
             
        }

        if(onScreenCount < 8) // If we have made less than 8 characters, spawn in the "make a new one" button
        {
            GameObject newCharaButton = Instantiate(newButtonPrefab, new Vector3(spawnpoints[onScreenCount].position.x, spawnpoints[onScreenCount].position.y, spawnpoints[onScreenCount].position.z), Quaternion.Euler(Vector3.zero), parentCanvas);    // Create the panel at the right position
        }

    }
}
