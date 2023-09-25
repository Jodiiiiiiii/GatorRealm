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
                _data.CharacterCount = 1; // SHOULD BE 0 IN THE FUTURE (workaround for no character select screen)
                _data.Characters = new CharacterData[MAX_CHARACTERS];
            }

            // components
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() // only called once (at program boot-up)
    {    }

    private void Update()
    {    }

    private void OnApplicationQuit()
    {
        // save saveData to json file
        string json = JsonUtility.ToJson(_data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
    #endregion

    #region DATA MODIFIERS
    /// <summary>
    /// useful for modifying stats of a particular character
    /// </summary>
    public CharacterData GetCharacter(int index)
    {
        if (_data.CharacterCount > index && index >= 0) // input validation
            return _data.Characters[index];

        // invalid index
        Debug.LogError("Invalid index for Characters array");
        return new CharacterData(); // default CharacterData
    }

    /// <summary>
    /// creates new blank character; useful when creating new blank character
    /// </summary>
    public void AddCharacter()
    {
        _data.Characters[_data.CharacterCount] = new CharacterData();
        _data.CharacterCount++;
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