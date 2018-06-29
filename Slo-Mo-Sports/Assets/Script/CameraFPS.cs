using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour
{

    private float sensitivityY = 3F;

    private float minimumX ;
    private float maximumX ;

    private float minimumY = -45f;
    private float maximumY = 45f ;

    float rotationY = 0F;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        
      
          //  rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
      
           rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
          rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            
            transform.localEulerAngles = new Vector3(-rotationY, 0 , 0);
        
     
    }
}   
