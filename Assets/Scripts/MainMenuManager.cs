using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource mainMenuMusic;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuMusic.loop = true;
        mainMenuMusic.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Day1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
