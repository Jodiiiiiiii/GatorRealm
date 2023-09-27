using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Extras;


/// <summary>
/// Manages all save data throughout scenes and between sessions
/// </summary>
public class GameManager : MonoBehaviour
{
    // Constants
    private const int MAX_CHARACTERS = 8;

    // instance - SINGLETON
    public static GameManager Instance;

    // components
    private AudioSource _audioSource;

    // save data
    [System.Serializable]
    private class SaveData
    {
        public int CharacterCount;
        public CharacterData[] Characters;
    }
    private SaveData _data;

    // private variables
    private int _currentCharacterIndex = -1; // None selected by default
    private bool _goingToNext = true;        // Controls the direction of the scene transition effect

    #region UNITY METHODS
    private void Awake() // called each time a scene is loaded/reloaded
    {
        // setup SavePointManager as a singleton class
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // initialize and load data
            _data = new SaveData();
            string path = Application.persistentDataPath + "/savedata.json";
            if (File.Exists(path))
            {
                // read json file into data object
                string json = File.ReadAllText(path);
                _data = JsonUtility.FromJson<SaveData>(json);
            }
            else // default save file configuration
            {
                _data.CharacterCount = 0;
                _data.Characters = new CharacterData[MAX_CHARACTERS];
            }

            // components
            _audioSource = GetComponent<AudioSource>();

            // TEMP - workaround without character select screen
            _data.CharacterCount = 1;
            _currentCharacterIndex = 0;
            _data.Characters[0] = new CharacterData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        // save saveData to json file
        string json = JsonUtility.ToJson(_data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
    #endregion

    #region DATA MODIFIERS
    /// <summary>
    /// gets currently selected character; used to modify current character
    /// </summary>
    public CharacterData GetCharacter()
    {
        if (_data.CharacterCount > _currentCharacterIndex && _currentCharacterIndex >= 0) // input validation
            return _data.Characters[_currentCharacterIndex];

        // invalid index
        Debug.LogError("Invalid index for Characters array");
        return null; // default CharacterData
    }

    /// <summary>
    /// creates new blank character; useful when creating new blank character
    /// </summary>
    public void AddCharacter()
    {
        _currentCharacterIndex = _data.CharacterCount;
        _data.Characters[_data.CharacterCount] = new CharacterData();
        _data.CharacterCount++;
    }

    public void SetCurrentCharacterIndex(int index)
    {
        _currentCharacterIndex = index;
    }

    public bool GetTransitionDirection()
    {
        return _goingToNext;
    }

    public void SetTransitionDirection(bool next)
    {
        _goingToNext = next;
    }
    #endregion

    #region SCENE MANAGEMENT
    public void TransitionScene(string sceneName)
    {
        // load new scene
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    #endregion

    #region AUDIO
    public void PlaySound(AudioClip clip, int volume)
    {
        _audioSource.PlayOneShot(clip, volume);
    }
    #endregion
}