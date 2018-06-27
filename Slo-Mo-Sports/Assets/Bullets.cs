using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    public float thrust;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
 
  
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Camera.main.transform.forward*thrust , ForceMode.Impulse);
    }
}
