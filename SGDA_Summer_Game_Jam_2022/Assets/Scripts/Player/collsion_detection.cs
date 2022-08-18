using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collsion_detection : MonoBehaviour
{
    private GameObject self;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) {
            case "Consumable":
                break;
            case "Enemy":
                
                break;
            case "Enviorment":
                break;
            case "Projectile":
                break;          
            default:
                break;
        }

    }

}
