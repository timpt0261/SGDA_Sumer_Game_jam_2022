using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour
{
   public bool debug_Mode;

    public int health = 5;
    public float gravity = 20.5f;
    public float speed = 200;
    
   

    //private SpriteRenderer sr;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    // For Jumping
    public float jumpVelocity = 10.0f;

    private bool OnGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask platformLayerMask;
    //Changes character mode
    private bool Is_human = true;

    // Player movemnet
    float move_Input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        //sr = GetComponent<SpriteRenderer>();
    }

     void FixedUpdate()
     {

        HandleMovemet();
        

    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //rb.gravityScale = gravity;
        Normal_Jump();
        if (move_Input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (move_Input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Is_human = !Is_human;
        }
    }

    void HandleMovemet() {
        move_Input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move_Input * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Normal_Jump()
    {

        OnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, platformLayerMask);

        if (OnGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

    }
    // Charge of Collsions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Process_Collsion(collision.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Process_Collsion(collision.gameObject);
    }

    void Process_Collsion(GameObject gameObject)
    {

        switch (gameObject.tag)
        {
            case "Consumable":
                HealPlayer();
                Debug.Log("Toughing Consumable");
                break;
            case "Enemy":
                DamagePlayer();
                Debug.Log("Touching Enemy");
                break;
            case "Enviorment":

                
                Debug.Log("Touching Enviorment");
                break;
            case "Projectile":
                DamagePlayer();
                Debug.Log("Touching Projectile");
                break;
            default:
                break;
        }


    }

    void DamagePlayer() {
        if (health == 0) {
            // Go back to spawn point
            // Make trigger to respawn smae enemy
            return;
        }

        // implement health bar
        health--;


    
    }

    void HealPlayer() {
        if(health == 5) {
            return;
        }

        // implement health bar
        health++;



    }
}
