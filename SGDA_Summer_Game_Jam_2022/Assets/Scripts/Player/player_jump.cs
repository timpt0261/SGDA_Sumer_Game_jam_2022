using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_jump : MonoBehaviour
{



    // For Jumping
    private Rigidbody2D rigidbody2D;
    public float jumpVelocity = 10.0f;

    private bool OnGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask platformLayerMask;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Normal_Jump();
        
    }

    void Normal_Jump() {

        OnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, platformLayerMask);

        if (OnGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }

    }
}
