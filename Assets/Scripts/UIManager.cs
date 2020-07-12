using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Quota quota;
    public Timer timer;
    public GameObject handbookButton;
    public GameObject gameOver;
    public GameObject employeeHandbook;
    public GameObject gameUI;
    public GameObject completedDay;

    public AudioSource bookSound;
    public AudioSource shiftEndSound;

    private GameManager _gameManager;

    public void Setup(int total, float timeLimit, GameManager gameManager)
    {
        _gameManager = gameManager;

        gameOver.SetActive(false);
        employeeHandbook.SetActive(false);
        gameUI.SetActive(true);
        quota.Setup(total);
        timer.Setup(timeLimit, this);
    }

    public void UpdateProgress()
    {
        quota.UpdateProgress();
    }

    public void TimesUp()
    {
        gameOver.SetActive(true);
        gameUI.SetActive(false);
        shiftEndSound.Play();
    }

    public void OpenHandbook()
    {
        timer.Pause();
        _gameManager.Pause();
        handbookButton.SetActive(false);
        employeeHandbook.SetActive(true);
        bookSound.Play();
    }

    public void CloseHandbook()
    {
        handbookButton.SetActive(true);
        timer.Unpause();
        _gameManager.Unpause();
        employeeHandbook.SetActive(false);
        bookSound.Play();
    }

    public void CompletedDay()
    {
        gameUI.SetActive(false);
        completedDay.SetActive(true);
    }
}
