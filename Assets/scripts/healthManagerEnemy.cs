using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManagerEnemy : MonoBehaviour
{
    public int health = 100;
    public void damage(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
