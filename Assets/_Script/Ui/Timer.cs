using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 120; // Durata del timer in secondi
    public TextMeshProUGUI timerText;
    public BlueEnemyAI blueEnemy;

    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            blueEnemy.ShowDefeatScreen();
        }
    }
}
