using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCanvas : MonoBehaviour
{
    public GameObject gameCanvas;
    public Button RetryButton;
    public GameObject winActive;
    public GameObject loseActive;

    void islosing()
    {
        if (loseActive.activeInHierarchy) 
        {
            RestartScene();
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
