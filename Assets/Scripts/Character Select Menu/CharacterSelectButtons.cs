using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectButtons : MonoBehaviour
{
    private ScreenTransition screenTransition;
    private CharacterDetailScreen detailScreen;

    public delegate void OnDetailPanelOpen();
    public static event OnDetailPanelOpen onDetailPanelOpen;
    public delegate void OnDetailPanelClose();
    public static event OnDetailPanelClose onDetailPanelClose;

    public delegate void OnDeletePanelOpen();
    public static event OnDeletePanelOpen onDeletePanelOpen;
    public delegate void OnDeletePanelClose();
    public static event OnDeletePanelClose onDeletePanelClose;

    private void Start()
    {
        screenTransition = FindObjectOfType<ScreenTransition>();
        detailScreen = FindObjectOfType<CharacterDetailScreen>();   
    }

    public void BackButton() // Goes back to the main menu
    {
        StopAllCoroutines();
        StartCoroutine(DoBackToMain());
    }

    public void NewCharaButton() // Moves you on to the new character scene
    {
        StopAllCoroutines();
        StartCoroutine(DoNewChara());
    }

    public void CharaDetailButton() // Pulls the detail window down
    {
        detailScreen.ShowPanel();
        onDetailPanelOpen?.Invoke();
        //TODO: Fade in raycast blocker for back layer of buttons
    }

    public void CloseCharaDetailButton() // Pushes the detail window up
    {
        detailScreen.HidePanel();
        onDetailPanelClose?.Invoke();
        //TODO: Fade out raycast blocker for back layer of buttons
    }

    public void DeleteButton()  // Calls down the delete confirmation window
    {
        //TODO: Fade in raycast blocker for back two layers of buttons
    }

    public void DeleteConfirmationButton()  // Confirms and executes deletion procedures
    {
        // Play the screen transition effect
        // Remove the character from the backend
        // Reload the scene
    }

    public void DeleteDenialButton()    // Backs the delete window down, keeps character intact
    {
        //TODO: Fade out raycast blocker for back two layers of buttons
    }

    // Coroutines --------------------------------------------------
    private IEnumerator DoBackToMain()
    {
        screenTransition.GoToPrevScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator DoNewChara()
    {
        GameManager.Instance.AddCharacter();
        screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
