﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public Transform goal;
    private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
         agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        agent.destination = goal.position;
	}
}
