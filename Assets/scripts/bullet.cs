using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Rigidbody rb;
 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        

        // Get the bullet's Rigidbody component and set its velocity based on the direction and bulletSpeed
        
        rb.velocity = transform.forward * bulletSpeed;
    }
}