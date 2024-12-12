using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject objectToSpawn; // Spawnlanacak prefab
    public Transform spawnPoint; // Objenin spawnlanaca�� nokta
    public float spawnInterval = 10f; // Spawn aral���

    void Start()
    {
        // Spawn fonksiyonunu tekrar eden �ekilde �a��r
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Prefab'� belirlenen noktada spawnla
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
