using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_jump : MonoBehaviour
{
    [SerializeField]
    internal player_input player_Input;


    //Jump Configuration
    [Range(1, 10)]
    internal float jumpVelocity;

    internal float jump_Multiplier = 2.5f;
    internal float low_jump_Multiplier = 2.0f;

   


    // Get grounded and get ceilling
    public void NormalJump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            player_Input.rb.velocity = Vector2.up * jumpVelocity;
        }
        
    }

    public void DoubleJump() { 
    
    }
}
