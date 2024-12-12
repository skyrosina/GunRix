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
        Cursor.visible = true; // Mouse imlecini g�r�n�r yapar
        Cursor.lockState = CursorLockMode.None; // Mouse'u kilitlenmemi� (serbest) duruma getirir
    }


    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName); // Belirtilen sahneyi y�kler
    }

    void RStartButton()
    {
        Debug.Log("Restart butonu �al��t�.");
        LoadScene("The_Viking_Village");
    }
    

    void ExitButton()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.Exit(0);
    #endif
        Debug.Log("Exit butonu �al��t�.");
    }
}
