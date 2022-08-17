using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_projectile : MonoBehaviour
{
    public GameObject player;
    public Transform firepoint;// empty game object where enmy is shooting from
    public GameObject projectile; // gameobject of existing projectile
    public float distance;// distance from player and enemy
    

    // Update is called once per frame    
    void Update()
    {
        // Detect distance from enemy

        // if distance met -> enwmy met
        // fomer code was implement to take input, didn't have anything for now
        if (true)
        {
            // shoot projectile
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(projectile, firepoint.position, firepoint.rotation);

    }

}

