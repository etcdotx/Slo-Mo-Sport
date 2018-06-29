using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public GameObject goal;
    private NavMeshAgent agent;
    public float radius = 3f;
    public float distance;
    private Rigidbody rb;
    public GameManager game;
    public GameObject explosion;

    public int hp = 3;
    private bool death = false;
    // Use this for initialization
    void Start () {
         agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag ("Player");
        agent.destination = goal.transform.position;
        rb = GetComponent<Rigidbody>();
        game = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        distance = Vector3.Distance(transform.position, goal.transform.position);
        if (radius > distance)
        {
            agent.speed = 0;
        }
        else {
            agent.speed = 20;
            agent.destination = goal.transform.position;
        }
        transform.LookAt(goal.transform);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") {

            rb.AddForce(collision.contacts[0].point * collision.rigidbody.mass,ForceMode.Force);
            
            if (!death && hp<=0) {
                game.kill++;
                death = true;
         
                GameObject explosions = Instantiate(explosion, transform.position, transform.rotation);
                Destroy(explosions, 2f);
            }
        }
    }

}
