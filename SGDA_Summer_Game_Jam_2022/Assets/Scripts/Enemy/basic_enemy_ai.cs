using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_enemy_ai : MonoBehaviour
{
    // This script will be placed on every instance of every simple enemy.
    // All Enemies should hurt the player on collision.
    // If the player hits an enemy, lower hitpoints of enemy.
    // When an enemy dies, they should play death animation/sprite, and then become untouchable.
    // Then Fade them out slowly, before destorying the object.

    // This script will not deal with enemy spawns.

    // Enemies will walk left to right. If they are on a platform, make them switch directions before they fall off.
    // Have variable patrol paths that can be set up in the editor.
    // Create a bool that determines if enemy is ranged or not. If we end up having more enemy types, I will come up with a different way
    // To know which enemy is which.


    int HP = 3;
    public bool isDead = false;
    SpriteRenderer mySprite;
    BoxCollider2D myCollider;
    Rigidbody2D myRigidBody;



    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
    }

    public void DamageEnemy()
    {
        if(isDead) return;
        HP--;
        if(HP <= 0) // Just being safe :P
        {
            StartCoroutine(DeathSequence());
        }
    }

    IEnumerator DeathSequence()
    {
        isDead = true;
        // Fling enemy up.
        // After a few seconds, start fading them out.
        // Once Opacity is equal to zero, destroy the object.


        Destroy(this.gameobject);

        yield return null;
    }
}
