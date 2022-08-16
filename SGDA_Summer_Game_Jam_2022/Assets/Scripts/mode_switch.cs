using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode_switch : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 300;
    private bool Is_human = true;

    float start_time = 0, pressed_time = 0;
    float cool_time = 3.0f;
    bool check = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Got help from forum
    // https://answers.unity.com/questions/815394/how-to-get-time-of-key-held-down.html

    void Update()
    {
        
        // play animation to switch to ghost

        // is ghost skin

        // if player is ghost and the left buttton is pressedhold for 1.5 sec
        if (Input.GetMouseButtonDown(0) && !check)
        {
            start_time = Time.time;
            pressed_time = start_time + cool_time;
            Debug.Log("Start Time: " + start_time + " ,  Pressed Time " + pressed_time);
            check = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            check = false;
        }

        if (Time.time >= pressed_time && check)
        {
            check = false;

            Movement_Mode();
            //Debug.Log("Left Mouse button pressed for more than 3 secs");

        }



    }



    // Determines if player in human mode or ghost mode
    void Movement_Mode()
    {

        if (!Is_human)
        {
            // play animation from human to ghost
            // switch to human skin

            // only able two direction 
            // not able to move through physical enemies
            // has gravity mass of one
            Debug.Log("In Human mode");

            Is_human = true;
            return;
        }

        Debug.Log("In Ghost Mode");
        Is_human = false;
        return;

    }
}
