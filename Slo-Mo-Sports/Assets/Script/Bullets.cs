using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    public float thrust;
    public bool hitenemy= false;
    Rigidbody rb;
    public GameObject impact;
    public AudioSource bounce;
    public AudioSource hitmech;
    // Use this for initialization
    void Start() {


        rb = GetComponent<Rigidbody>();

        rb.AddForce(Camera.main.transform.forward * thrust, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        bounce.Stop();
        bounce.Play();
        if (other.gameObject.tag == "Props"|| other.gameObject.tag == "Enemy")
        {
            
            StartCoroutine(lifetime());
            if (other.gameObject.tag == "Enemy") {

                GameObject impactgo = Instantiate(impact, other.contacts[0].point, Quaternion.LookRotation(other.contacts[0].normal));
                Destroy(impactgo, 0.5f);
                hitmech.Stop();
                hitmech.Play();

                if (!hitenemy)
                {
                    other.gameObject.GetComponent<Enemy>().hp--;
                    hitenemy = true;
                }
                if (other.gameObject.GetComponent<Enemy>().hp <= 0)
                {
                    Destroy(other.gameObject, 0.1f);
                }

            }
        }
    }
    

    IEnumerator lifetime()
    {
        yield return new WaitForSeconds(5);
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        Destroy(this.gameObject);
    }
}
