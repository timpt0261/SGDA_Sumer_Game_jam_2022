using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_crouch : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite standing;
    public Sprite crouching; 

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private Vector2 standing_Size;
    private Vector2 crouching_Size;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        bc.size = standing_Size;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standing;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("crouch"))
        {
            
        }

        if (Input.GetButtonUp("crouch"))
        {

        }
    }
}
