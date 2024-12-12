using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject objectToSpawn; // Spawnlanacak prefab
    public Transform spawnPoint; // Objenin spawnlanacaðý nokta
    public float spawnInterval = 10f; // Spawn aralýðý

    void Start()
    {
        // Spawn fonksiyonunu tekrar eden þekilde çaðýr
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Prefab'ý belirlenen noktada spawnla
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
