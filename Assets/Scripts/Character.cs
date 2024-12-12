using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    // Bu method, düþmanýn Collider'ý karakterin Collider'ý ile çarpýþtýðýnda çalýþacak.

    private void OnCollisionEnter(Collision collision)
    {
        // Eðer çarpýþan nesne "Character" tag'ine sahipse (Karakterinizi tanýmlamak için bir tag kullanabilirsiniz)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Karakteri yok et
            Debug.Log("OnTCollisionEnter Çalýþtý");
            Destroy(collision.gameObject);
        }
    }

    // Eðer Trigger kullanýyorsanýz OnTriggerEnter de kullanýlabilir.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter Çalýþtý");
            Destroy(other.gameObject);
        }
    }
}
