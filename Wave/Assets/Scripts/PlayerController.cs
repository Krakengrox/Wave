using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float velocity;
    public float verticalImpulse;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = 10f;
        verticalImpulse = 20f;
        Manager.gManager.player = this;
    }

    void Update()
    {
        if (Input.GetKey("space"))
        {
            rb.AddForce(transform.up * verticalImpulse);
        }

        //rb.AddForce(transform.forward * velocity * Input.GetAxis("Horizontal"));
        rb.AddForce (transform.right *velocity * Input.GetAxis("Horizontal"));
    }
}
