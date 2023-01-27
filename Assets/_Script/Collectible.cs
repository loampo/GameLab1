using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public Slider jumpSlider;
    private bool canJump = false;
    public float jumpForce = 5.0f;
    private float jumpDuration = 10f;
    private float jumpTimer = 0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectibleJump"))
        {
            canJump = true;
            Destroy(other.gameObject);
            jumpTimer = jumpDuration;
            jumpSlider.maxValue = jumpDuration;
            jumpSlider.value = jumpTimer;
        }
    }

    private void Update()
    {
        if (canJump && jumpTimer > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            jumpTimer -= Time.deltaTime;
            jumpSlider.value = jumpTimer;
        }
        else
        {
            canJump = false;
        }
    }
}