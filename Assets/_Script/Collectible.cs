using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public bool _CanJump=false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("CollectibleJump"))
        {
            _CanJump = true;
            Destroy(other.gameObject);
            
        }
    }
}