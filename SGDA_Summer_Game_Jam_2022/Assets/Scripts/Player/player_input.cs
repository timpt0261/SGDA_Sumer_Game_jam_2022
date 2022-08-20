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
    [SerializeField]
    private LayerMask platformLayerMask;
    //[SerializeField]
    //private Transform groundCheck;
    //public float checkRadius = .5f;

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
        move_Input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move_Input * speed * Time.fixedDeltaTime, rb.velocity.y);

    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //rb.gravityScale = gravity;

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


    // Charge of Collsions
}
