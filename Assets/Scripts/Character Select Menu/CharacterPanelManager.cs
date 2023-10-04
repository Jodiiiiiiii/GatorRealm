using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private GameObject newButtonPrefab;
    [SerializeField] private Transform parentCanvas;

    [SerializeField] private FadeUI raycastBlocker1;
    [SerializeField] private FadeUI raycastBlocker2;

    private bool loaded = false;

    private void OnEnable()
    {
        CharacterSelectButtons.onDetailPanelOpen += FadeInBlocker1;
        CharacterSelectButtons.onDetailPanelClose += FadeOutBlocker1;
    }

    private void OnDisable()
    {
        CharacterSelectButtons.onDetailPanelOpen -= FadeInBlocker1;
        CharacterSelectButtons.onDetailPanelClose -= FadeOutBlocker1;
    }

    void Start()
    {
        loaded = false;
        raycastBlocker1.gameObject.SetActive(false);
        raycastBlocker2.gameObject.SetActive(false);
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

    private void FadeInBlocker1()
    {
        raycastBlocker1.gameObject.SetActive(true);
        raycastBlocker1.UIFadeIn();
    }

    private void FadeInBlocker2()
    {
        raycastBlocker2.gameObject.SetActive(true);
        raycastBlocker2.UIFadeIn();
    }

    private void FadeOutBlocker1()
    {
        raycastBlocker1.UIFadeOut();
    }

    private void FadeOutBlocker2()
    {
        raycastBlocker2.UIFadeOut();
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
