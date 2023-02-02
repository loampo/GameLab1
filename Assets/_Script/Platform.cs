using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HoverControlRay>(out HoverControlRay hoverControlRay))
        {
            hoverControlRay.transform.rotation = direction.rotation;
        }
 
    }

  



}
