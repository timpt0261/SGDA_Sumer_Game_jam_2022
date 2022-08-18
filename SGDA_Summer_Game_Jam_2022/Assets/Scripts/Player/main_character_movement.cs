using UnityEngine;

public class main_character_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 200;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(horizontal, vertical);

        rb.velocity = dir * speed * Time.fixedDeltaTime;


    }
}
