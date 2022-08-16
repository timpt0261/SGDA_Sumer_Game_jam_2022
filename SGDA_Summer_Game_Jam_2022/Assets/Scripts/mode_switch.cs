using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_c : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 300;
    private bool mode;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mode = true;

    }

    // Update is called once per frame
    void Update()
    {
        // play animation to switch to ghost

        // is ghost skin

        // movment limiatations

        Movement();
    }

    void Movement() {
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("In Human Mode");
        }else if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("In Ghost Mode");
        }
    }
}
