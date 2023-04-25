using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    public GameObject impactPNG;
    public int Damage = 35;
    public ParticleSystem particle;

    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject impactEffectGO = Instantiate(impactPNG, hit.point, Quaternion.identity) as GameObject;
                Destroy(impactEffectGO, 3f);
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    healthManagerEnemy health = hit.collider.gameObject.GetComponent<healthManagerEnemy>();
                    health.damage(Damage);
                }
                if (hit.collider.gameObject.tag == "TNT")
                {
                    tntExpload tntScript = hit.collider.gameObject.GetComponent<tntExpload>();
                    Instantiate(particle, hit.point, Quaternion.identity);
                    tntExpload.isBlown = true;
                    tntExpload.tnt = hit.collider.gameObject;
                }
            }
        }
    }
}
