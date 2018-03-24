using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour
{

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

        
      
          //  rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
      
           rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
          rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            
            transform.localEulerAngles = new Vector3(-rotationY, 0 , 0);
        
     
    }
}   
