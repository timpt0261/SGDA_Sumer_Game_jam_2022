using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour
{
   public bool debug_Mode;

    
    public float gravity = 20.5f;
    public float speed = 200;

    //private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Rigidbody2D rbt;
    private BoxCollider2D bc;

    [SerializeField]
    private LayerMask platformLayerMask;
    private float jumpVelocity = 100.0f;
    private float fall_Multiplier = 2.5f;
    private float low_jump_Multiplier = 2.0f;

    //Changes character mode
    private bool Is_human = true;

    // Player movemnet
    float horizontal;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rbt = transform.GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        //sr = GetComponent<SpriteRenderer>();
    }

    // Got help from forum
    // https://answers.unity.com/questions/815394/how-to-get-time-of-key-held-down.html

    void Update()
    {

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player is jumping");
            rbt.velocity = Vector2.up * jumpVelocity;
        }

        horizontal = Input.GetAxisRaw("Horizontal");



        //// In ghost Mode
        //if (!Is_human)
        //{
        //    rb.gravityScale = gravity / 2.0f;

        //    // Damage is double



        //}
        //else {
        //    // In Human Mode

        //    rb.gravityScale = gravity;
        //    // Normal Jump



        //}

        // able to go through walls
        //bc.isTrigger = !Is_human ? true : false;


        // if left mouse button clicked mode is switched 
        if (Input.GetMouseButtonDown(0))
        {

            Is_human = !Is_human;
        }


        Vector2 dir = new Vector2(horizontal, 0);

        rb.velocity = dir * speed * Time.fixedDeltaTime;
    }

    /// In control of the player's ablity to jump

    //public void NormalJump()
    //{
        

    //}


    public void Better_Jump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fall_Multiplier - 1);


        }

    }

    private bool IsCeiling()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bc.bounds.center,bc.size, 0f, Vector2.up, 1f, platformLayerMask);
        Debug.Log(raycastHit2D);

        return raycastHit2D.collider != null;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bc.bounds.center, bc.size, 0f, Vector2.down, 1f, platformLayerMask);
        if(debug_Mode) Debug.Log(raycastHit2D.collider + " Raycast collider intercting: " + raycastHit2D.collider != null);

        return raycastHit2D.collider != null;
    }


    // Charge of Collsions
}
