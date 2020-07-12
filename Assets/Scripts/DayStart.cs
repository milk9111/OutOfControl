using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayStart : MonoBehaviour
{
    public GameObject gameUI;

    public AudioSource startShiftSound;

    public AudioSource conveyorBeltSound;

    private GameManager _gameManager;

    private CursorControls _cursorControls;

    void Start()
    {
        gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _cursorControls = GameObject.FindObjectOfType<CursorControls>();
    }

    public void BeginDay()
    {
        gameUI.gameObject.SetActive(true);
        _cursorControls.MouseExit();
        _gameManager.BeginDay();

        startShiftSound.Play();
        conveyorBeltSound.Play();

        gameObject.SetActive(false);
    }
}
