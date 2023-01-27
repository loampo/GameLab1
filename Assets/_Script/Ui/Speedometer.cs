using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Slider speedometer;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float currentSpeed = rb.velocity.magnitude;
        float fillAmount = 10* currentSpeed / GameObject.Find("Player").GetComponent<HoverControlRay>().maxSpeed;
        Debug.Log("Fill Amount: " + fillAmount);
        speedometer.value = fillAmount;
    }
}
