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

        navMeshAgent = GetComponent<NavMeshAgent>(); // NavMeshAgent'� al
        navMeshAgent.destination = target.position;

    }

    void Update()
    {

        if (target != null  )
        {
            if (Input.GetKeyDown(KeyCode.T)) // Bo�luk tu�una bas�ld���nda zaman� durdur/ba�lat
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
                 navMeshAgent.ResetPath(); // Karakter uzakta ise d��man durur
             }*/
        }
    }


        
    
    void StopTime()
    {
        Time.timeScale = 0f; // Zaman� durdurur
        isTimeStopped = true;
    }

    void ResumeTime()
    {
        Time.timeScale = 1f; // Zaman� normale d�nd�r�r
        isTimeStopped = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter �al��t�");
            LoadScene("GameOverScene");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Belirtilen sahneyi y�kler
    }

}
