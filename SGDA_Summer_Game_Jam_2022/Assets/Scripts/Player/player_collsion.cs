using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collsion : MonoBehaviour
{

    private GameObject self;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Process_Collsion(collision.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Process_Collsion(collision.gameObject);
    }

    void Process_Collsion(GameObject gameObject) {

        switch (gameObject.tag)
        {
            case "Consumable":
                Debug.Log("Toughing Consumable");
                break;
            case "Enemy":
                Debug.Log("Touching Enemy");
                break;
            case "Enviorment":
                Debug.Log("Touching Enviorment");
                break;
            case "Projectile":
                Debug.Log("Touching Projectile");
                break;
            default:
                break;
        }


    }

}
