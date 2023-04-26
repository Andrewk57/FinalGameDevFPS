using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float cameraSpeed = .06f;
    public float jumpForce = 5f;
    [SerializeField]
    public GameObject heart1, heart2, heart3, heart4, heart5, heart6;
    public int timesHit = 0;
    private Rigidbody rb;
    public bool isGrounded = true;
    //public LayerMask ground;
    public GameObject deathScreen;
    public static bool isDead = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isDead = false;
    }
    void Update()
    {
        //Debug.Log(timesHit);
      if(isDead == false)
        {
            float translation = Input.GetAxis("Vertical") * cameraSpeed;
            float strafe = Input.GetAxis("Horizontal") * cameraSpeed;
            transform.Translate(strafe, 0, translation);

            if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1f && isGrounded == true)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
            
        

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
            isDead = true;
            //setDeathScreenOn, pause time ect..
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
        }
           
        }
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            timesHit++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("floor"))
        {
            Debug.Log("Entered floor");
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            Debug.Log("Left floor");
            isGrounded = false;
        }
    }

}
