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
    /// <summary>
    /// Update solo per far andare nelle flag e nel caso le prenda tutte mostra la schermata di sconfitta
    /// </summary>
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
    /// <summary>
    /// Appena prende la bandiera la distrugge e decresce il numero di bandiere da raccogliere che vengono mostrate sullo schermo
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedFlag"))
        {
            redFlags.Remove(other.transform);
            nRedFlag.text = redFlags.Count.ToString();
            Destroy(other.gameObject);
        }
    }
    /// <summary>
    /// Oltre a mostrare la sconfitta mette in pausa
    /// </summary>
    public void ShowDefeatScreen()
    {
        
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
