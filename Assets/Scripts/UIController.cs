using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIController : MonoBehaviour
{

    public Button restartButton;
    public Button exitButton;


    private void Start()
    {
        restartButton.onClick.AddListener(RStartButton);
        exitButton.onClick.AddListener(ExitButton);
        Cursor.visible = true; // Mouse imlecini görünür yapar
        Cursor.lockState = CursorLockMode.None; // Mouse'u kilitlenmemiþ (serbest) duruma getirir
    }


    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName); // Belirtilen sahneyi yükler
    }

    void RStartButton()
    {
        Debug.Log("Restart butonu çalýþtý.");
        LoadScene("The_Viking_Village");
    }
    

    void ExitButton()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.Exit(0);
    #endif
        Debug.Log("Exit butonu çalýþtý.");
    }
}
