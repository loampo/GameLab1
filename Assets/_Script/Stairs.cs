using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Vector3 offsetRising;
    public BoxCollider colliderStairUp;
    public BoxCollider[] colls;
    public Dictionary<Collider, string> collidersMap = new Dictionary<Collider, string>();

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<HoverControlRay>(out HoverControlRay player))
        {
            if (player.transform.position.y - transform.position.y < 0)
            {
                player.GetComponent<CharacterController>().Move(offsetRising + new Vector3(0, 0, colliderStairUp.bounds.size.z));
                player.transform.position += offsetRising + new Vector3(0, 0, colliderStairUp.bounds.size.z);
            }
        }
    }
}
