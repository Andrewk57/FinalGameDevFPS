using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float cameraSpeed = .06f;
    public float jumpForce = 5f;
    

    void Update()
    {
      
            float translation = Input.GetAxis("Vertical") * cameraSpeed;
            float strafe = Input.GetAxis("Horizontal") * cameraSpeed;
            transform.Translate(strafe, 0, translation);
        

       
    }
}