using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonMap2 : MonoBehaviour
{
    public void Restart()
    {
        // code to reload the current scene
        {

            SceneManager.LoadScene("game2");

        }

    }
}
