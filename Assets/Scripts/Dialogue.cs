using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;


    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        
    }


    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {

                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }


    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypleLine());
    }

    IEnumerator TypleLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    
    void NextLine()
    {
        if (index < (lines.Length - 1))
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypleLine());
        }
        else
        {
            gameObject.SetActive(false);
            sceneManage();
            


        }
    }

    void sceneManage()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            // Uygulamayý kapat
            Application.Quit();

            // Unity Editör'de çalýþýrken uygulamanýn kapanmasýný simüle etmek için
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene("The_Viking_Village");
        }
    }

}