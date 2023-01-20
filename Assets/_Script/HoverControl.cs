using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverControl : MonoBehaviour
{
    public float hoverHeight = 3.0f;
    public float hoverForce = 5.0f;
    public float hoverDamping = 0.5f;
    public float forwardAcceleration = 2000.0f;
    public float backwardAcceleration = 2000.0f;
    public float turnStrength = 10.0f;
    public float maxSpeed = 100.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate the hover force
        Vector3 hoverVector = new Vector3(0, hoverForce, 0);
        float displacementY = transform.position.y - hoverHeight;
        hoverVector -= displacementY * Vector3.up * hoverDamping;

        // Apply the hover force
        rb.AddForce(hoverVector);

        // Calculate the forward/backward force
        float acceleration = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            acceleration = forwardAcceleration;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            acceleration = -backwardAcceleration;
        }
        rb.AddForce(transform.forward * acceleration * Time.deltaTime);

        // Limit the speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Calculate the turn force
        float turn = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(Vector3.up * turn * turnStrength);
    }
}
