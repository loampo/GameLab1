using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{

    public Slider jumpSlider;
    //private bool canJump = false;
    //public float jumpForce = 5.0f;
    //private float jumpDuration = 10f;
    //private float jumpTimer = 0f;
    public TextMeshProUGUI nJump;
    private float increaseNJump = 0f;
    public float jumpForce = 5.0f;
    public Rigidbody rb;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nJump.text = increaseNJump.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("CollectibleJump"))
        //{
        //    canJump = true;
        //    Destroy(other.gameObject);
        //    jumpTimer = jumpDuration;
        //    jumpSlider.maxValue = jumpDuration;
        //    jumpSlider.value = jumpTimer;
        //} CAMBIARE CON SEMAFORO
        if (other.CompareTag("CollectibleJump"))
        {
            increaseNJump += 1f;
            Destroy(other.gameObject);
            UpdateFundsDisplay();
        }
    }

    private void Update()
    {

        
        //if (canJump && jumpTimer > 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //    }
        //    jumpTimer -= Time.deltaTime;
        //    jumpSlider.value = jumpTimer;
        //}
        //else
        //{
        //    canJump = false;
        //}
      
        if (increaseNJump > 0)
        {
            jumpSlider.value = 1;
            if (Input.GetKeyDown(KeyCode.Space)&& Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                increaseNJump -= 1f;
                jumpSlider.value = 0;
                UpdateFundsDisplay();
            }
        }
    }
    private void UpdateFundsDisplay()
    {
        nJump.text = increaseNJump.ToString();
        //jumpSlider.value = 1;
    }
}

