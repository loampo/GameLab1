using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPosition : MonoBehaviour
{
    public Slider slider;
    public Rigidbody rb;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float angle = Vector3.SignedAngle(rb.velocity, rb.transform.forward, rb.transform.up);
        //_image.rectTransform.rotation = Quaternion.Euler(0, 0, angle);

    }



}
