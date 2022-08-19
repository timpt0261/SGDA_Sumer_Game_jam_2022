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

    // changes character direction
    private bool facing = true;
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
        
        Handle_Movement();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Is_human = !Is_human;
        }
    }

    /// In control of the player's ablity to jump

    private void Handle_Movement() {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = gravity;

        move_Input = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(move_Input, rb.velocity.y);
        rb.velocity = dir * Time.fixedDeltaTime * speed;

        if (!facing && move_Input > 0)
        {
            Flip();
        }
        else if (facing && move_Input < 0)
        {
            Flip();
        }

    }


    private void Flip()
    {
            facing = !facing;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
    }

    //private void Normal_Jump() {
        


    //}


    //public void Better_Jump()
    //{
    //    if (rb.velocity.y < 0)
    //    {
    //        rb.velocity += Vector2.up * Physics2D.gravity.y * (fall_Multiplier - 1) * Time.fixedDeltaTime;


    //    } else if (rb.velocity.y > 0) { 

            
    //    }

    //}

    private bool IsCeiling()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bc.bounds.center,bc.size, 0f, Vector2.up, 1f, platformLayerMask);
        Debug.Log(raycastHit2D);

        return raycastHit2D.collider != null;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bc.bounds.center, bc.size, 0f, Vector2.down, 1f, platformLayerMask);
        Debug.Log(raycastHit2D.collider + " Raycast collider intercting: " + raycastHit2D.collider != null);
        

        return raycastHit2D.collider != null;
    }


    // Charge of Collsions
}
