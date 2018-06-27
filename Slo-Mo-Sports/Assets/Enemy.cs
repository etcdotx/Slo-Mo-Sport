using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public Transform goal;
    private NavMeshAgent agent;
    public float radius = 3f;
    public float distance;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
         agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        distance = Vector3.Distance(transform.position, goal.position);
        if (radius > distance)
        {
            agent.speed = 0;
        }
        else {
            agent.speed = 20;
            agent.destination = goal.position;
        }
        transform.LookAt(goal);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") {
            Debug.Log(collision.contacts[0].point);
            rb.AddForce(collision.contacts[0].point * collision.rigidbody.mass,ForceMode.Force);
        }
    }

}
