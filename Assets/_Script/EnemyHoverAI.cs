using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class EnemyHoverAI : MonoBehaviour
{
    //public Transform flag;
    public List<Transform> flags; //Adesso ci servono più bandiere
    public float speed = 5.0f;
    private Rigidbody rb;
    NavMeshAgent agent;
    public float attackRadius = 10.0f;
    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(flag.position);
        agent.SetDestination(flags[0].position);
    }

    void Update()
    {
        //transform.LookAt(flag);
        //rb.AddForce(transform.forward * speed);
        //Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < attackRadius)
        {
            // Attack the player
            transform.LookAt(player);
            rb.AddForce(transform.forward * speed);
        //}
        //else
        //{
            // Go to flag
        //if (!agent.pathPending && !agent.hasPath)
        //{
        //        score++;
        //        Destroy(flag.gameObject);
        //    }
        }
    }

    public int score = 0;
    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Flag"))
        //{
        //    score++;
        //    Destroy(other.gameObject);
        //}
        if (other.CompareTag("Flag"))
        {
            flags.Remove(other.transform);
            agent.SetDestination(flags[0].position);
            score++;
            Destroy(other.gameObject);
        }
    }
}
