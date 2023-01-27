using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject options;
    public Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        options.SetActive(true);
    }


    public void ReturnOptions()
    {
        options.SetActive(false);
    }


}