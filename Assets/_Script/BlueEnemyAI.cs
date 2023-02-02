using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BlueEnemyAI : MonoBehaviour
{
    public List<Transform> redFlags;
    public GameObject loseCanvas;

    public TextMeshProUGUI nRedFlag;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(redFlags[0].position);
        nRedFlag.text = redFlags.Count.ToString();
    }

    private void Update()
    {
        if (redFlags.Count > 0)
        {
            agent.SetDestination(redFlags[0].position);
        }
        if (redFlags.Count == 0)
        {
            ShowDefeatScreen();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedFlag"))
        {
            redFlags.Remove(other.transform);
            nRedFlag.text = redFlags.Count.ToString();
            Destroy(other.gameObject);
        }
    }

    public void ShowDefeatScreen()
    {
        
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
