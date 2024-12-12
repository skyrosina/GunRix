using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class IntroSceneButton : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(sahneDegis);

    }

    void sahneDegis()
    {
        SceneManager.LoadScene("MainScene");
    }
}
