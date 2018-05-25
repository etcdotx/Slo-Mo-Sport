using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public Transform goal;
    private NavMeshAgent agent;
    public float radius = 3f;
    public float distance;
    // Use this for initialization
    void Start () {
         agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update () {
        distance = Vector3.Distance(transform.position, goal.position);
        if (radius > distance)
        {
            agent.isStopped = true;
        }
        else {
            agent.isStopped = false;
            agent.destination = goal.position;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

}
