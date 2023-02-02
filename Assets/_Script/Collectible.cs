using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{

    public Slider jumpSlider;
    public TextMeshProUGUI nJump;
    private float increaseNJump = 0f;
    public float jumpForce = 5.0f;
    public Rigidbody rb;
    private float delay = 5f;
    public GameObject wall;
    private float increaseNWall = 0f;
    public TextMeshProUGUI nWall;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nJump.text = increaseNJump.ToString();
        nWall.text = increaseNWall.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectibleJump"))
        {
            increaseNJump += 1f;
            Destroy(other.gameObject);
            UpdateFundsDisplayJump();
        }
        if (other.CompareTag("CollectibleWall"))
        {
            increaseNWall += 1f;
            Destroy(other.gameObject);
            UpdateFundsDisplayWall();

        }
    }

    private void Update()
    {
        if (increaseNJump > 0)
        {
            jumpSlider.value = 1;
            if (Input.GetKeyDown(KeyCode.Space)&& Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                increaseNJump -= 1f;
                jumpSlider.value = 0;
                UpdateFundsDisplayJump();
            }
        }

        if (increaseNWall > 0)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                increaseNWall -= 1f;
                StartCoroutine(Wall());
                UpdateFundsDisplayWall();
            }
        }
            
    }
    private void UpdateFundsDisplayJump()
    {
        nJump.text = increaseNJump.ToString();
    }
    private void UpdateFundsDisplayWall()
    {
        nWall.text = increaseNWall.ToString();
    }


    public IEnumerator Wall()
    {
        
        wall.SetActive(true);
        yield return new WaitForSeconds(delay);
        wall.SetActive(false);
        
    }



}

