using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        
        LoadScene("FinalScene");
    }
    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName); // Belirtilen sahneyi yükler
    }

    
}
