using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public GameObject terminationLetter;

    public Transform _target;

    public float scrollSpeed;

    public bool rollCredits;

    void Start()
    {
        //terminationLetter.SetActive(true);
        rollCredits = true;
    }

    void Update()
    {
        if (!rollCredits)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, scrollSpeed * Time.deltaTime);
    }

    public void RollCredits()
    {
        rollCredits = true;
        terminationLetter.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
