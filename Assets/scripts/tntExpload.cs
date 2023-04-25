using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tntExpload : MonoBehaviour
{
    public static bool isBlown = false;
    public float radius;
    public static GameObject tnt;
    public AudioSource expload;

    private void Start()
    {
        tnt = this.gameObject;
    }
    private void Update()
    {
        if (isBlown == true && tnt == this.gameObject)
        {
            //Debug.Log(isBlown);
            expload.Play();
            Collider[] enemies = Physics.OverlapSphere(transform.position, radius);
            Debug.Log("Got enemies");
            Debug.Log(enemies.Length);
            foreach (Collider collider in enemies)
            {
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject);
                    Debug.Log("Destroyed enemies");
                }
            }
            
            Destroy(this.gameObject);
            
            isBlown = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

