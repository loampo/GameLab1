using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BlueEnemyAI : MonoBehaviour
{
    public List<Transform> blueFlags;
    public GameObject loseCanvas;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(blueFlags[0].position);
    }

    private void Update()
    {
        if (blueFlags.Count > 0)
        {
            agent.SetDestination(blueFlags[0].position);
        }
        if (blueFlags.Count == 0)
        {
            ShowDefeatScreen();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueFlag"))
        {
                blueFlags.Remove(other.transform);
                Destroy(other.gameObject);
        }
    }

        void ShowDefeatScreen()
    {
        
        loseCanvas.SetActive(true);
        ////You can also set the defeat message on the canvas
    }
}
