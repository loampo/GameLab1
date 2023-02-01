using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    public void Restart()
    {
        // code to reload the current scene
        {
            
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);


        }

    }

    public void NextGame()
    {
        // code to reload the current scene
        {

            SceneManager.LoadScene("game2");

        }

    }

}
