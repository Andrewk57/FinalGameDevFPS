using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}

