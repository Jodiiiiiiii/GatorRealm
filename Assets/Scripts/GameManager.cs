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
    // first character selected unless otherwise specified
    private int _selectedCharacterIndex = 0;

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
#if UNITY_EDITOR
                // prevents crash when starting editor from CharacterCreation scene with no existing .json file
                _data.Characters[0] = new CharacterData();
#endif
            }

            // components
            _audioSource = GetComponent<AudioSource>();
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
    /// For CHARACTOR CREATION:
    /// gets currently selected character;
    /// used to modify/view current character data within CharacterCreation scene
    /// </summary>
    public CharacterData GetCharacter()
    {
        // index already input validated elsewhere
        return _data.Characters[_selectedCharacterIndex];
    }

    /// <summary>
    /// For CHARACTER SELECT: 
    /// used to get any character (e.g. for CharacterSelect displays)
    /// </summary>
    /// <returns>Character at index</returns>
    public CharacterData GetCharacter(int index)
    {
        if (index >= 0 && index < MAX_CHARACTERS)
            return _data.Characters[index];

        // invalid index
        Debug.LogError("GetCharacter(index): Invalid character index input");
        return new CharacterData(); // default CharacterData
    }

    /// <summary>
    /// For CHARACTER SELECT:
    /// creates new blank character; call this when user adds new character in CharacterSelect
    /// </summary>
    public void AddCharacter()
    {
        if (_data.CharacterCount < MAX_CHARACTERS)
        {
            // initialize character with new character data
            _data.Characters[_data.CharacterCount] = new CharacterData();

            _data.CharacterCount++;
        }
        else
            Debug.LogError("AddCharacter: max capacity; unable to add character");
    }

    /// <summary>
    /// For CHARACTER SELECT: 
    /// call this to remove a specific index;
    /// The result will shift remaining characters so only smallest possible indices are used
    /// </summary>
    public void RemoveCharacter(int index)
    {
        if (index >= 0 && index < MAX_CHARACTERS)
        {
            // left shift characters to the right of removed index
            for(int i = index; i < _data.CharacterCount-1; i++)
                _data.Characters[i] = _data.Characters[i + 1];

            _data.CharacterCount--;
        }
        else
            Debug.LogError("RemoveCharacter(index): Invalid character index input");
    }

    /// <summary>
    /// For CHARACTER SELECT: 
    /// call this to set currently selected index BEFORE loading into CharacterCreation scene
    /// </summary>
    public void SetSelectedCharacterIndex(int index)
    {
        if (index >= 0 && index < MAX_CHARACTERS)
            _selectedCharacterIndex = index;
        else
            Debug.LogError("SetCurrentCharacterIndex(index): Invalid character index input");
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