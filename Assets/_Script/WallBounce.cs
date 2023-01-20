using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    public float bounceForce = 500.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 reflection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.AddForce(reflection * bounceForce, ForceMode.Impulse);
        }
    }
}
