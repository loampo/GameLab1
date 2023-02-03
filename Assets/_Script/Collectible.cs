using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    //Only fo Slider
    public Slider jumpSlider;
    public Slider InvisiSlider;
    public Slider ShieldSlider;
    //public Slider SemaforoSlider; //Semaforo fa crashare
    private float ShieldTimer;
    private float ShieldDuration = 20f;
    private float delayInvicibility = 20f; //Shield duration

    public TextMeshProUGUI nJump;
    private float increaseNJump = 0f;
    public float jumpForce = 5.0f;
    public Rigidbody rb;
    private float delayWall = 10f;
    private float delayEnemy = 10f;
    public GameObject wallPrefab;
    private float increaseNWall = 0f;
    public TextMeshProUGUI nWall;
    public bool shield=false;
    private float increaseNShield = 0f;
    public TextMeshProUGUI nInvisibility;
    private float increaseNInvisibility = 0f;
    public List<GameObject> platforms;
    public GameObject greenEnemy;
    private HoverControlRay playermovement;
    





    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nJump.text = increaseNJump.ToString();
        nWall.text = increaseNWall.ToString();
        nInvisibility.text = increaseNWall.ToString();
        playermovement = GetComponent<HoverControlRay>();

        //Dichiaro vari slider
        ShieldTimer = 0f;
        ShieldSlider.value = ShieldTimer;

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
            ShieldTimer = ShieldDuration;
            ShieldSlider.maxValue = ShieldDuration;
            ShieldSlider.value = ShieldTimer;
        }
        if (other.CompareTag("CollectibleInvisibily"))
        {
            increaseNInvisibility += 1f;
            Destroy(other.gameObject);
            UpdateFundsDisplayInvisibility();
        }
        
        if (other.CompareTag("CollectibleSemRed"))
        { 
            Destroy(other.gameObject);
            StartCoroutine(playermovement.SemaforoRed());
        }
        if (other.CompareTag("CollectibleSemGreen"))
        {
            Destroy(other.gameObject);
            StartCoroutine(playermovement.SemaforoGreen());
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
                StartCoroutine (Wall());                
            }
        }

        if (increaseNShield > 0)
        {
            increaseNShield -= 1f;
            StartCoroutine(Shield());
            

        }
        if (ShieldTimer > 0)
        {
            ShieldTimer -= Time.deltaTime;
            ShieldSlider.value = ShieldTimer;
        }

        if (shield == true)
        {
            StartCoroutine(SetActivePlatform());
        }

        if (increaseNInvisibility > 0)
        {
            if (Input.GetKey(KeyCode.Alpha3))
            {
                increaseNInvisibility -= 1f;
                UpdateFundsDisplayInvisibility();
                StartCoroutine(Invisibility());
            }
        }
        //Semaforo fa crashare
        //if (increaseNSemRed > 0)
        //{
        //    increaseNSemRed -= 1f;
        //    StartCoroutine(playercontrol.SemaforoRed());
        //}
        //if (increaseNSemGreen > 0)
        //{
        //    increaseNSemGreen -= 1f;
        //    StartCoroutine(playercontrol.SemaforoGreen());
        //}

    }
    private void UpdateFundsDisplayJump()
    {
        nJump.text = increaseNJump.ToString();
    }
    private void UpdateFundsDisplayWall()
    {
        nWall.text = increaseNWall.ToString();
    }
    private void UpdateFundsDisplayInvisibility()
    {
        nInvisibility.text = increaseNInvisibility.ToString();
    }



    private IEnumerator Wall()
    {

        Vector3 wallPosition = transform.position - transform.forward * 2.0f;
        GameObject newWall = Instantiate(wallPrefab, wallPosition, Quaternion.identity);
        yield return new WaitForSeconds(delayWall);
        Destroy(newWall);
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

    public IEnumerator Invisibility()
    {
        
        greenEnemy.SetActive(false);
        yield return new WaitForSeconds(delayEnemy);
        greenEnemy.SetActive(true);
    }


}

