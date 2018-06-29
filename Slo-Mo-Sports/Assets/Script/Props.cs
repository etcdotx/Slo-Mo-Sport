using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet") {
            Destroy(other.gameObject);
        }
    }
}
