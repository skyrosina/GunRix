using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    // Bu method, d��man�n Collider'� karakterin Collider'� ile �arp��t���nda �al��acak.

    private void OnCollisionEnter(Collision collision)
    {
        // E�er �arp��an nesne "Character" tag'ine sahipse (Karakterinizi tan�mlamak i�in bir tag kullanabilirsiniz)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Karakteri yok et
            Debug.Log("OnTCollisionEnter �al��t�");
            Destroy(collision.gameObject);
        }
    }

    // E�er Trigger kullan�yorsan�z OnTriggerEnter de kullan�labilir.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter �al��t�");
            Destroy(other.gameObject);
        }
    }
}
