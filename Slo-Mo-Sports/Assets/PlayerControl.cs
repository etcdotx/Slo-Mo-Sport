using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float sensitivityX = 15F;
    public TimeManager time;
    public Camera fpscam;
    public GameObject bullet;
    public Transform guns;
    public float firerate =10f;

    private float nexttimetofire = 0f;
    // Use this for initialization
    void Start()
    {
        time = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")|| Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            time.backtonormal();
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -speed * Time.deltaTime);
            }
            if (Input.GetButtonDown("Fire1") && Time.time >= nexttimetofire ) {
                nexttimetofire = Time.time + 1f / firerate;
                shoot();
            }
         
        }
        else
        {
            time.doslowmotion();
        }
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);
    }

    void shoot() {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit)) {
            Debug.Log(hit.transform.tag);
        }
        Instantiate(bullet,guns.position,guns.rotation);
    }

}
