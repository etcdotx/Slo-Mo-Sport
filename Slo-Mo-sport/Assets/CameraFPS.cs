using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour
{

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX ;
    public float maximumX ;

    public float minimumY ;
    public float maximumY ;

    float rotationY = 0F;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationX = Mathf.Clamp(rotationX, -45, maximumX);
        Debug.Log(rotationX);
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            transform.parent.localEulerAngles = new Vector3(0, rotationX, 0);
     
    }
}   
