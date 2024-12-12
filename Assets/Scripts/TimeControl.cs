using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    // Düþmanlarýn Rigidbody bileþenlerini referans alacaðýmýz array
    
    public GameObject[] enemies;  // Düþman karakterlerinin GameObject'leri
    private Rigidbody[] enemyRb;

    // Oyuncunun hareketini kontrol etmek için (örneðin, WASD tuþlarý)
    private bool isPlayerMoving = false;
    private bool isTimePaused = false;

    void Start()
    {
        // Düþmanlarýn Rigidbody bileþenlerini alýyoruz
        enemyRb = new Rigidbody[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyRb[i] = enemies[i].GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // WASD tuþlarýndan birine basýldýðýnda oyuncu hareket ediyor
        isPlayerMoving = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));

        // Eðer oyuncu hareket etmeye baþladýysa, zaman baþlayacak (yani düþmanlar hareket etmeye baþlayacak)
        if (isPlayerMoving && isTimePaused)
        {
            ResumeTime(); // Düþmanlarýn hareketini baþlat
        }
        // Eðer oyuncu hareket etmiyorsa, zaman duracak (yani düþmanlar duracak)
        else if (!isPlayerMoving && !isTimePaused)
        {
            PauseEnemies(); // Düþmanlarýn hareketini durdur
        }
    }

    // Düþmanlarýn hareketini durdur
    void PauseEnemies()
    {
        Time.timeScale = 0f; // Zamaný durdur

        // Düþmanlarýn hareketini engelle
        foreach (Rigidbody rb in enemyRb)
        {
            rb.isKinematic = true; // Düþmanlarýn hareketini durdur
        }

        isTimePaused = true;  // Zamanýn durduðuna dair iþaret
    }

    // Düþmanlarýn hareketini baþlat
    void ResumeTime()
    {
        Time.timeScale = 1f; // Zamaný normale döndür

        // Düþmanlarýn hareketine tekrar izin ver
        foreach (Rigidbody rb in enemyRb)
        {
            rb.isKinematic = false; // Düþmanlarýn hareketini baþlat
        }

        isTimePaused = false; // Zaman baþlatýldý
    }
}