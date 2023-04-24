using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float cameraSpeed = .06f;
    public float jumpForce = 5f;
    //public GameObject player;
    [SerializeField]
    public GameObject heart1, heart2, heart3, heart4, heart5, heart6;
    public int timesHit =0;
    void Update()
    {
        Debug.Log(timesHit);
      
            float translation = Input.GetAxis("Vertical") * cameraSpeed;
            float strafe = Input.GetAxis("Horizontal") * cameraSpeed;
            transform.Translate(strafe, 0, translation);

        if (timesHit == 1)
        {
            Destroy(heart6);
        }
        else if (timesHit == 2)
        {
            Destroy(heart5);
        }
        else if (timesHit == 3)
        {
            Destroy(heart4);
        }
        else if (timesHit == 4)
        {
            Destroy(heart3);
        }
        else if (timesHit == 5)
        {
            Destroy(heart2);
        }
        else if (timesHit == 6)
        {
            Destroy(heart1);
            //setDeathScreenOn, pause time ect..
        }
            /*if (timesHit == 1)
            {
                Destroy(heart6);

                if (timesHit == 2)
                {
                    Destroy(heart5);
                    if (timesHit == 3)
                    {
                        Destroy(heart4);
                        if (timesHit == 4)
                        {
                            Destroy(heart3);
                            if (timesHit == 5)
                            {
                                Destroy(heart2);
                                if (timesHit == 6)
                                {
                                    Destroy(heart1);
                                    //set deathscreen to active
                                }
                            }
                        }
                    }
                }
            }*/
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            timesHit++;
            Destroy(collision.gameObject);
        }
    }
}
