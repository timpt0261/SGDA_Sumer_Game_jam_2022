using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour
{
    [SerializeField]
    internal player_controller player_Controller;

    [SerializeField]
    internal player_jump player_Jump;

    public bool debug_Mode;

    
    public float gravity = 20.5f;
    public float speed = 200;
    public float cool_time = 3.0f; //time it takes to transform

    internal SpriteRenderer sr;
    internal Rigidbody2D rb;
    internal BoxCollider2D bc;

    //Changes character mode
    private bool Is_human = true;

    // Player movemnet
    float horizontal;

    //Jump Configuration
    [Range (1,10)]
    internal float jumpVelocity;

    internal float jump_Multiplier = 2.5f;
    internal float low_jump_Multiplier = 2.0f;

    void Awake() { 
    
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Got help from forum
    // https://answers.unity.com/questions/815394/how-to-get-time-of-key-held-down.html

    void Update()
    {
        // In ghost Mode
        if (!Is_human)
        {

            // Damage is double

            // Double Jump active
            player_Jump.DoubleJump();
            
        }
        else {
            // In Human Mode
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpVelocity;
                player_Jump.NormalJump();

            }


        }
        //gravit dependent of mode
        rb.gravityScale = Is_human ? gravity : 0;
        // able to go through walls
        //bc.isTrigger = !Is_human ? true : false;

        horizontal = Input.GetAxisRaw("Horizontal");
        // able to move 2 or 4 directions depending on mode
        //vertical = !Is_human ? Input.GetAxisRaw("Vertical") : 0;



        // if left mouse button clicked mode is switched 
        if (Input.GetMouseButtonDown(0)) { 
            
            Is_human = !Is_human; 
        }
       
        Vector2 dir = new Vector2(horizontal, 0);

        rb.velocity = dir * speed * Time.fixedDeltaTime;


    }
}
