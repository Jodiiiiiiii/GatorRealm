using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectButtons : MonoBehaviour
{
    private ScreenTransition screenTransition;
    private CharacterPanelManager panelManager;
    private PanelController detailScreen;
    private PanelController deleteScreen;

    [SerializeField] private Animator buttonAnim;

    private bool activeCoroutine;

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
        panelManager = FindObjectOfType<CharacterPanelManager>();
        detailScreen = GameObject.Find("Character Detail Panel").GetComponent<PanelController>();
        deleteScreen = GameObject.Find("Confirm Delete Panel").GetComponent<PanelController>();
    }

    private void OnMouseOver()
    {
        //Debug.Log("It work");
        
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
        // So, this also needs to tell the panel manager the index of whatever button we just clicked on
        panelManager.SetSelectedIndex(GetComponentInParent<CharacterPanel>().GetIndex());
        detailScreen.ShowPanel();
        onDetailPanelOpen?.Invoke();
    }

    public void PlayButton()
    {
        StartCoroutine(DoPlay());
    }


    public void CloseCharaDetailButton() // Pushes the detail window up
    {
        detailScreen.HidePanel();
        onDetailPanelClose?.Invoke();
    }

    public void DeleteButton()  // Calls down the delete confirmation window
    {
        deleteScreen.ShowPanel();
        onDeletePanelOpen?.Invoke();
    }

    public void DeleteConfirmationButton()  // Confirms and executes deletion procedures
    {
        StartCoroutine(DoDeleteChara());
    }

    public void DeleteDenialButton()    // Backs the delete window down, keeps character intact
    {
        deleteScreen.HidePanel();
        onDeletePanelClose?.Invoke();
    }

    public void MouseOver()
    {
        if (buttonAnim != null && !activeCoroutine)
        {
           StartCoroutine(DoMouseOverAnim());
        }
    }

    // Coroutines --------------------------------------------------
    private IEnumerator DoBackToMain()
    {
        screenTransition.GoToPrevScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator DoPlay()
    {
        screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }

    private IEnumerator DoDeleteChara()
    {
        screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);

        // This is where we need to delete whatever character is currently selected from the backed
        GameManager.Instance.RemoveCharacter(panelManager.GetSelectedIndex());

        SceneManager.LoadScene(1);
    }

    private IEnumerator DoNewChara()
    {
        GameManager.Instance.AddCharacter();
        screenTransition.GoToNextScene();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

    private IEnumerator DoMouseOverAnim()
    {
        activeCoroutine = true;
        buttonAnim.Play("PosterMouseOver", 0, 0);
        yield return new WaitForSeconds(1f);
        activeCoroutine = false;
    }
}
