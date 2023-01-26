using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverControlRay : MonoBehaviour
{
    public float hoverHeight = 3.0f;
    public float hoverForce = 5.0f;
    public float forwardAcceleration = 2000.0f;
    public float backwardAcceleration = 2000.0f;
    public float turnStrength = 50.0f;
    public float maxSpeed = 100.0f;
    public float jumpForce = 5.0f;
    public LayerMask groundLayers;

    public Rigidbody rb;
    private Vector3 raycastDirection = Vector3.down;
    public GameObject winCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate the hover force
        RaycastHit hit;
        if (Physics.Raycast(transform.position, raycastDirection, out hit, hoverHeight, groundLayers))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

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
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnStrength * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnStrength * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void ShowVictoryScreen()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0; //Pause the game
        //You can also set the victory message on the canvas
    }
}
