using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour
{
   
    public bool debug_Mode;
    public Animator animator;


    public int health = 5;
    public float invulnerblity = 1.0f;
    public float gravity = 20.5f;
    public float speed = 200;
    
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
 
   
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
    int extra = 2;
    bool IsCrouching = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

     void FixedUpdate()
     {

        HandleMovemet();
        
    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKeyDown(KeyCode.S) && !IsCrouching)
        {
            IsCrouching = true;
            Debug.Log("Is crouching");
            animator.SetBool("IsCrouching", true);
        }

        if (Input.GetKeyUp(KeyCode.S) && IsCrouching)
        {
            IsCrouching = false;
            Debug.Log("Is not crouching");
            animator.SetBool("IsCrouching", false);

        }
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
            // implement filter
            //player goes through enemies
        }
    }

    void HandleMovemet() {
        
        move_Input = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move_Input));
        rb.velocity = new Vector2(move_Input * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Jump()
    {
       
        
        OnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, platformLayerMask);

       
        if (OnGround && Input.GetKeyDown(KeyCode.Space) && extra >= 0)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            //animator.SetBool("IsJump", true);
        }

        if (rb.velocity.y > 0)
        {
        }
        else if (rb.velocity.y < 0) { }

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



    // These method are in control of the player death and spawn point 
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    private void Process_Collsion(GameObject gameObject)
    {

        switch (gameObject.tag)
        {
            case "Consumable":
                HealPlayer();
                Debug.Log("Toughing Consumable");
                break;
            case "Enemy":
                DamagePlayer();
                animator.SetBool("IsHurt", true);
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
        return;

    }

    void DamagePlayer() {
        animator.SetBool("IsHurt", true);
        if (health == 0) {
            animator.SetBool("IsDead", true);
            // Go back to spawn point
            // Make trigger to respawn same enemy
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
