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
    public Slider SemGreenSlider;
    public Slider SemRedSlider;
    private float InvisiTimer;
    private float InvisiDuration = 10f;
    private float ShieldTimer;
    private float ShieldDuration = 20f;
    private float SemGreenTimer;
    private float SemRedTimer;
    private float SemDuration = 10f;
    private bool isInvisibilityActive = false;
    //private float delayInvicibility = 20f; Ex Shield duration
    //private float delayEnemy = 10f; ExInvisiduration

    public TextMeshProUGUI nJump;
    private float increaseNJump = 0f;
    public float jumpForce = 10.0f;
    public Rigidbody rb;
    private float delayWall = 10f;
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
        playermovement = GetComponent<HoverControlRay>(); //mi serve per richiamare la coroutine dal HoverControlRay

        //Dichiaro vari slider a 0 per lo start
        ShieldTimer = 0f;
        ShieldSlider.value = ShieldTimer;
        SemRedTimer = 0f;
        SemRedSlider.value = SemRedTimer;
        SemGreenTimer = 0f;
        SemGreenSlider.value = SemGreenTimer;
        InvisiTimer = 0f;
        InvisiSlider.value = InvisiTimer;
    }
    /// <summary>
    /// Ci sono i trigger di tutti i collezzionabili disponibili
    /// </summary>
    /// <param name="other"></param>
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
            SemRedTimer = SemDuration;
            SemRedSlider.maxValue = SemDuration;
            SemRedSlider.value = SemRedTimer;
            StartCoroutine(playermovement.SemaforoRed());
        }
        if (other.CompareTag("CollectibleSemGreen"))
        {
            Destroy(other.gameObject);
            SemGreenTimer = 10.0f;
            SemGreenSlider.maxValue = 10.0f;
            SemGreenSlider.value = SemGreenTimer;
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
        //Ho collegato InvisiTimer alla coroutine così da avere un if e non avere problemi se premi più volte il tasto
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            increaseNInvisibility -= 1f;
            UpdateFundsDisplayInvisibility();
            InvisiTimer = InvisiDuration;
            InvisiSlider.maxValue = InvisiDuration;
            InvisiSlider.value = InvisiTimer;
            StartCoroutine(Invisibility());
        }
        //Timer necessari per visualizzare su schermo per quanto tempo c'è il buff o debuff
        if (SemRedTimer > 0)
        {
            SemRedTimer -= Time.deltaTime;
            SemRedSlider.value = SemRedTimer;
        }
        if (SemGreenTimer > 0)
        {
            SemGreenTimer -= Time.deltaTime;
            SemGreenSlider.value = SemGreenTimer;
        }
    }
    //Tutti gli UpdateFunds servono per aggiornare i vari testi in base alle quantità trasformate in stringhe per poterli riportare senza errori
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


    /// <summary>
    /// Prendo un prefab e lo piazzo nel mondo secondo le coordina descritte in base alla posizione del giocatore con anche un autodistruzione
    /// </summary>
    /// <returns></returns>
    private IEnumerator Wall()
    {

        Vector3 wallPosition = transform.position - transform.forward * 3.0f;
        wallPosition.y += 1.0f;
        GameObject newWall = Instantiate(wallPrefab, wallPosition, transform.rotation);
        yield return new WaitForSeconds(delayWall);
        Destroy(newWall);
    }


    public IEnumerator Shield()
    {
        shield = true;
        yield return new WaitForSeconds(ShieldDuration);
        shield = false;
    }
    /// <summary>
    /// Riesce a prendere tutti i GameObject della lista platforms e li disattiva temporaneamente
    /// È l'effetto che diamo allo Shield se preso
    /// </summary>
    /// <returns></returns>
    public IEnumerator SetActivePlatform()
    {
        for (int i =0; i<platforms.Count;i++)
        {
            GameObject gameObject = platforms[i];
            gameObject.SetActive(false);

        }
        yield return new WaitForSeconds(ShieldDuration);
        for (int i = 0; i < platforms.Count; i++)
        {
            GameObject gameObject = platforms[i];
            gameObject.SetActive(true);
        }

    }
    /// <summary>
    /// Riesce a controllare InvisiTimer e non disattivarsi a caso se il giocatore decidesse di resettare il tempo senza aspettare la fine
    /// </summary>
    /// <returns></returns>
    public IEnumerator Invisibility()
    {
        greenEnemy.SetActive(false);
        while (InvisiTimer > 0)
        {
            yield return null;
            InvisiTimer -= Time.deltaTime;
            InvisiSlider.value = InvisiTimer;
        }
        greenEnemy.SetActive(true);

    }


}

