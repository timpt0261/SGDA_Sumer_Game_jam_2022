using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour
{
   
    public bool debug_Mode;
       

    public int health = 5;
    public float gravity = 20.5f;
    public float speed = 200;
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    [SerializeField]
    private CapsuleCollider2D cc;
    
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
    bool IsCrouching = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

     void FixedUpdate()
     {

        HandleMovemet();
        

    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //rb.gravityScale = gravity;
        Jump();
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
        
        
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))&& IsCrouching) {
            Debug.Log("Pressed crouch: " + cc.enabled);
            cc.enabled = false;
            IsCrouching = !IsCrouching;
           
        }

        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && !IsCrouching) {
            Debug.Log("Releasing crouch: " + cc.enabled);
            cc.enabled = true;
            IsCrouching = !IsCrouching;
        }

        move_Input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move_Input * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Jump()
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
