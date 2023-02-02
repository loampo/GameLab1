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
    private float delayInvicibility = 20f;
    private float delayWall = 10f;
    public GameObject wall;
    private float increaseNWall = 0f;
    public TextMeshProUGUI nWall;
    public bool shield=false;
    private float increaseNShield = 0f;
    public TextMeshProUGUI nShield;
    public List<GameObject> platforms;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nJump.text = increaseNJump.ToString();
        nWall.text = increaseNWall.ToString();
        nShield.text = increaseNWall.ToString();
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
        if (other.CompareTag("CollectibleShield"))
        {
            increaseNShield += 1f;
            Destroy(other.gameObject);
            UpdateFundsDisplayShield();
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
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                increaseNWall -= 1f;
                UpdateFundsDisplayWall();
                StartCoroutine(Wall());
                
            }
        }

        if (increaseNShield > 0)
        {
                increaseNShield -= 1f;
                StartCoroutine(Shield());
                UpdateFundsDisplayShield();
            
        }
        
        if (shield == true)
        {
            StartCoroutine(SetActivePlatform());
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
    private void UpdateFundsDisplayShield()
    {
        nShield.text = increaseNShield.ToString();
    }

    private IEnumerator Wall()
    {
        
        wall.SetActive(true);
        yield return new WaitForSeconds(delayWall);
        wall.SetActive(false);
        
    }


    public IEnumerator Shield()
    {
        shield = true;
        yield return new WaitForSeconds(delayInvicibility);
        shield = false;
    }

    public IEnumerator SetActivePlatform()
    {
        for (int i =0; i<platforms.Count;i++)
        {
            GameObject gameObject = platforms[i];
            gameObject.SetActive(false);

        }
        yield return new WaitForSeconds(delayInvicibility);
        for (int i = 0; i < platforms.Count; i++)
        {
            GameObject gameObject = platforms[i];
            gameObject.SetActive(true);
        }

    }


}

