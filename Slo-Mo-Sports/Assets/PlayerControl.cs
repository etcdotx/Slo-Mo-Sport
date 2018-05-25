using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float sensitivityX = 15F;
    public TimeManager time;
    // Use this for initialization
    void Start()
    {
        time = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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
         
        }
        else
        {
            time.doslowmotion();
        }
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);
    }
}
