using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    // D��manlar�n Rigidbody bile�enlerini referans alaca��m�z array
    
    public GameObject[] enemies;  // D��man karakterlerinin GameObject'leri
    private Rigidbody[] enemyRb;

    // Oyuncunun hareketini kontrol etmek i�in (�rne�in, WASD tu�lar�)
    private bool isPlayerMoving = false;
    private bool isTimePaused = false;

    void Start()
    {
        // D��manlar�n Rigidbody bile�enlerini al�yoruz
        enemyRb = new Rigidbody[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyRb[i] = enemies[i].GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // WASD tu�lar�ndan birine bas�ld���nda oyuncu hareket ediyor
        isPlayerMoving = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));

        // E�er oyuncu hareket etmeye ba�lad�ysa, zaman ba�layacak (yani d��manlar hareket etmeye ba�layacak)
        if (isPlayerMoving && isTimePaused)
        {
            ResumeTime(); // D��manlar�n hareketini ba�lat
        }
        // E�er oyuncu hareket etmiyorsa, zaman duracak (yani d��manlar duracak)
        else if (!isPlayerMoving && !isTimePaused)
        {
            PauseEnemies(); // D��manlar�n hareketini durdur
        }
    }

    // D��manlar�n hareketini durdur
    void PauseEnemies()
    {
        Time.timeScale = 0f; // Zaman� durdur

        // D��manlar�n hareketini engelle
        foreach (Rigidbody rb in enemyRb)
        {
            rb.isKinematic = true; // D��manlar�n hareketini durdur
        }

        isTimePaused = true;  // Zaman�n durdu�una dair i�aret
    }

    // D��manlar�n hareketini ba�lat
    void ResumeTime()
    {
        Time.timeScale = 1f; // Zaman� normale d�nd�r

        // D��manlar�n hareketine tekrar izin ver
        foreach (Rigidbody rb in enemyRb)
        {
            rb.isKinematic = false; // D��manlar�n hareketini ba�lat
        }

        isTimePaused = false; // Zaman ba�lat�ld�
    }
}