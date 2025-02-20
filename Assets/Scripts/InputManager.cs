using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;   
    public string nameInput;
    public TextMeshProUGUI inputText;
    
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

    // Update is called once per frame
    void Update()
    {
        
    }
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
