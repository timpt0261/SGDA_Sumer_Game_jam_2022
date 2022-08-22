using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public bool debug_Mode;
    public Animator animator;


    public float health = 5;

    public float gravity = 20.5f;
    public float speed = 200;
    public float invulnerblity = 1.0f;


    private Renderer render;
    private Rigidbody2D rb;

    // Player movemnet
    float move_Input;
    bool IsCrouching = false;

    private int extrajumps;
    public int extraJumpsValue;

    // For Jumping
    public float jumpVelocity = 10.0f;
    private bool OnGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask platformLayerMask;

    //Changes character mode
    private bool Is_human = true;
    [SerializeField]
    private Color ghostColor = Color.white; 

   


    void Start()
    {
        extrajumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
        render.material.color = Color.white;

    }

    void FixedUpdate()
    {
        OnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, platformLayerMask);



        HandleMovemet();

    }

    void Update()
    {
        Debug.Log("On the ground: " + OnGround);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Crouch();

        if (OnGround)
        {
            animator.SetBool("IsFarJump", false);
        }
        else{
            animator.SetBool("IsFarJump", true);
        }
        Jump();
        Flip();
        Mode_Switch();

    }
    void Crouch() {
        if (Input.GetKeyDown(KeyCode.S) && !IsCrouching)
        {
            IsCrouching = true;
            Debug.Log("Is crouching");
            animator.SetBool("IsCrouching", true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !IsCrouching)
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
        else if (Input.GetKeyUp(KeyCode.DownArrow) && IsCrouching)
        {
            IsCrouching = false;
            Debug.Log("Is not crouching");
            animator.SetBool("IsCrouching", false);

        }

    }
    void HandleMovemet() 
    {
        move_Input = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move_Input));
        rb.velocity = new Vector2(move_Input * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Jump()
    {
        if (OnGround) {
            extrajumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extrajumps > 0)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            extrajumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && OnGround && extrajumps == 0) 
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
       



    }
    void Flip() {
        // flips character face
        if (move_Input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (move_Input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    void Mode_Switch(){
        // changes character mode
        if (Input.GetMouseButtonDown(0))
        {
            Is_human = !Is_human;
            
            // implement filter
            //player goes through enemies
        }

        if (Is_human)
        {
            render.material.color = Color.white;
        }
        else {
            render.material.color = ghostColor;
        }

    }
    // Charge of Collsions at the begining

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
        //animator.SetBool("IsFarJump", false);
        //animator.SetBool("IsJump", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsDead", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //animator.SetBool("IsFarJump", false);
        //animator.SetBool("IsJump", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsDead", false);

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
