using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    
    
    // AudioSource bileþeni
    private AudioSource audioSource;

    // Silah ateþleme sesi
    public AudioClip fireSound;

    void Start()
    {
        // AudioSource bileþenini al
        audioSource = GetComponent<AudioSource>();

        // Ses dosyasýný atama (isteðe baðlý)
        if (fireSound != null)
        {
            audioSource.clip = fireSound;
        }
    }

    void Update()
    {
        // Sol týk kontrolü
        if (Input.GetMouseButtonDown(0)) // 0: Sol týklama
        {
            // Ses çal
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
