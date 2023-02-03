using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class HoverControlRay : MonoBehaviour
{
    public float SemaforoSpeed = 5.0f;
    public float SemaforoAcceleration = 400.0f;


    public float hoverHeight = 5.0f;
    public float hoverForce = 5.0f;
    public float forwardAcceleration = 1500.0f;
    public float backwardAcceleration = 1500.0f;
    public float turnStrength = 70.0f;
    public float maxSpeed = 13.0f;
    public Menu menu;

    bool arrows;

    public GameObject nPause;

    public LayerMask groundLayers;
    

    public Rigidbody rb;
    private Vector3 raycastDirection = Vector3.down;

    public GameObject winCanvas;
    public List<Transform> blueFlags;
    
    
    public TextMeshProUGUI nBlueFlag;
    public TextMeshProUGUI nScore;
    private float bluFlagScore;
    Collectible collectible;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nBlueFlag.text = blueFlags.Count.ToString();
        menu = FindObjectOfType<Menu>();
    }

    void Update()
    {
        if (!menu.optionsSet)
        {
            arrows = false;
            RaycastHit hit;
            // Calculate the hover force
            if (Physics.Raycast(transform.position, raycastDirection, out hit, hoverHeight, groundLayers))
            {
                float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
                Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
                rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
                //Debug.Log("Distanza dal suolo: " + hit.distance); Per qualche motivo non funziona
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
        }
        else 
        {
            arrows = true;
            RaycastHit hit;
            // Calculate the hover force
            if (Physics.Raycast(transform.position, raycastDirection, out hit, hoverHeight, groundLayers))
            {
                float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
                Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
                rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
                //Debug.Log("Distanza dal suolo: " + hit.distance); Per qualche motivo non funziona
            }

            // Calculate the forward/backward force
            float acceleration = 0.0f;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                acceleration = forwardAcceleration;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                acceleration = -backwardAcceleration;
            }
            rb.AddForce(transform.forward * acceleration * Time.deltaTime);

            // Limit the speed
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -turnStrength * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, turnStrength * Time.deltaTime);
            }
        }


        if (blueFlags.Count == 0)
        {
            ShowVictoryScreen();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueFlag"))
        {
            blueFlags.Remove(other.transform);
            bluFlagScore += 350f;
            nScore.text = bluFlagScore.ToString();
            nBlueFlag.text = blueFlags.Count.ToString();
            Destroy(other.gameObject);
        }
    }

    void ShowVictoryScreen()
    {

        winCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            nPause.SetActive(false);
            Time.timeScale = 1;
        } else if (Time.timeScale == 1)
        {
            nPause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public IEnumerator SemaforoGreen()
    {
        maxSpeed += SemaforoSpeed;
        forwardAcceleration += SemaforoAcceleration;
        backwardAcceleration += SemaforoAcceleration;
        yield return new WaitForSeconds(10f);
        maxSpeed -= SemaforoSpeed;
        forwardAcceleration -= SemaforoAcceleration;
        backwardAcceleration -= SemaforoAcceleration;
    }
    public IEnumerator SemaforoRed()
    {
        maxSpeed -= SemaforoSpeed;
        forwardAcceleration -= SemaforoAcceleration;
        backwardAcceleration -= SemaforoAcceleration;
        yield return new WaitForSeconds(10f);
        maxSpeed += SemaforoSpeed;
        forwardAcceleration += SemaforoAcceleration;
        backwardAcceleration += SemaforoAcceleration;
    }
}
