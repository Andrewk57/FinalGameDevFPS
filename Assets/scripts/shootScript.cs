using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    //public GameObject shootPoint;
    public GameObject impactPNG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject impactEffectGO = Instantiate(impactPNG, hit.point, Quaternion.identity) as GameObject;
                Destroy(impactEffectGO, 3f);
            }
        }
    }
    
}
