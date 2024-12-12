using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    
    
    // AudioSource bile�eni
    private AudioSource audioSource;

    // Silah ate�leme sesi
    public AudioClip fireSound;

    void Start()
    {
        // AudioSource bile�enini al
        audioSource = GetComponent<AudioSource>();

        // Ses dosyas�n� atama (iste�e ba�l�)
        if (fireSound != null)
        {
            audioSource.clip = fireSound;
        }
    }

    void Update()
    {
        // Sol t�k kontrol�
        if (Input.GetMouseButtonDown(0)) // 0: Sol t�klama
        {
            // Ses �al
            PlayFireSound();
        }
    }

    void PlayFireSound()
    {
        if (audioSource != null && fireSound != null)
        {
            audioSource.Play();
        }
    }
}
