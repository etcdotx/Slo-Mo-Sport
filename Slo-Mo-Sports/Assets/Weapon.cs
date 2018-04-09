using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public Camera fpscamera;
	void Update () {
        if (Input.GetMouseButtonDown(1)) {
            shoot();
        }
	}

    void shoot() {
        RaycastHit hit;
        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range)) {
            Debug.Log("HIT");
        }
    }
	

}
