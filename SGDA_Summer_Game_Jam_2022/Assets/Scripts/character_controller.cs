using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    public bool debug_Mode;
    public float gravity = 20.5f;
    public float speed = 200;
    public float cool_time = 3.0f; //time it takes to transform

    private Rigidbody2D rb;
    private bool Is_human = true;
    private float start_time = 0, pressed_time = 0;
    private bool check = false;


    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Got help from forum
    // https://answers.unity.com/questions/815394/how-to-get-time-of-key-held-down.html

    void Update()
    {
        //gravit dependent of mode
        rb.gravityScale = Is_human ? gravity : 0;
 
        horizontal = Input.GetAxisRaw("Horizontal");
        // able to move 2 or 4 directions depending on mode
        vertical = !Is_human ? Input.GetAxisRaw("Vertical") : 0;
        
       
     

        // if player is ghost and the left buttton is pressedhold for 1.5 sec
        if (Input.GetMouseButtonDown(0) && !check)
        {
            start_time = Time.time;
            pressed_time = start_time + cool_time;
            if (debug_Mode) {
                Debug.Log("Start Time: " + start_time + " ,  Pressed Time " + pressed_time);
            }
           
            check = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            check = false;
        }
        // if the current time and the tiem the left button is 
        if (Time.time >= pressed_time && check)
        {
            check = false;

            Is_human = !Is_human;

        }
       
        Vector2 dir = new Vector2(horizontal, vertical);

        rb.velocity = dir * speed * Time.fixedDeltaTime;


    }
}
