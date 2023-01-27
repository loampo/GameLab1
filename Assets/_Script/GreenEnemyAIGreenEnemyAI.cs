using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenEnemyAIGreenEnemyAI : MonoBehaviour
{
    public Transform Player;
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if (distanceToPlayer < 500f)
        {
            agent.destination = Player.position;
        }
        else if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        agent.destination = Locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % Locations.Count;
    }
}
