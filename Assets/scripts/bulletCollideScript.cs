using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletCollideScript : MonoBehaviour
{
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            
            Debug.Log("Hit floor");
        }
        Destroy(gameObject);
    }
}
