using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;   
    public string nameInput;
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI outputText;

    private string BestScoreName;
    private int BestScoreScore;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
          
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
       
    }
    private void Start()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            Debug.Log("path exist");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScoreName = data.name;
            BestScoreScore = data.score;
        }
        outputText.text = "Best Score: " + BestScoreName + " : " + BestScoreScore;
    }
    class SaveData
    {
        public string name;
        public int score;
    }

    // Update is called once per frame

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
    public void ReadInput()
    {
        nameInput = inputText.text;
        Debug.Log(nameInput);
    }
}
