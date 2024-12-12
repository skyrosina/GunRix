using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MoveTo : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navMeshAgent;

    private bool isTimeStopped = false;


    private void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>(); // NavMeshAgent'ý al
        navMeshAgent.destination = target.position;

    }

    void Update()
    {

        if (target != null  )
        {
            if (Input.GetKeyDown(KeyCode.T)) // Boþluk tuþuna basýldýðýnda zamaný durdur/baþlat
            {
                if (isTimeStopped)
                {
                    ResumeTime();
                }
                else
                {
                    StopTime();
                }
            }

            navMeshAgent.SetDestination(target.position);

            /* float distanceToPlayer = Vector3.Distance(transform.position, target.position);

             if (distanceToPlayer <= 40f)
             {
                 navMeshAgent.SetDestination(target.position);
             }
             else
             {
                 navMeshAgent.ResetPath(); // Karakter uzakta ise düþman durur
             }*/
        }
    }


        
    
    void StopTime()
    {
        Time.timeScale = 0f; // Zamaný durdurur
        isTimeStopped = true;
    }

    void ResumeTime()
    {
        Time.timeScale = 1f; // Zamaný normale döndürür
        isTimeStopped = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter Çalýþtý");
            LoadScene("GameOverScene");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Belirtilen sahneyi yükler
    }

}
