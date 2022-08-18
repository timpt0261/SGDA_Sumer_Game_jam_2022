using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_movement : MonoBehaviour
{
    // for projectile it self

    public float speed = 250f; // the speed at which the projectile will move
    public float time_alive = 2.5f; // time the projectile wil apear on screen
    public Rigidbody2D rb; // the game objects rigidbody
    public GameObject self;// the projectile itself
    // Start is called before the first frame update
    void Start()
    {
        //don't know if it will work try to get it to move towards the player's direction/postion
        rb.velocity = transform.forward * speed * Time.deltaTime; 
        
    }
    private void Update()
    {
        // After set amount of second the projectile shoul destroy itself 
        Destroy(self, time_alive);
    }
}
