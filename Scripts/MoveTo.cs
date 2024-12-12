using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>(); // NavMeshAgent'ý al
        navMeshAgent.destination = target.position;

    }

    void Update()
    {
        if (target != null)
        {
            // Hedefin yeni pozisyonunu NavMeshAgent'a bildir
            navMeshAgent.SetDestination(target.position);
        }
    }


}
