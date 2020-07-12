using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int quota;
    public float timeInSec;
    public int finishedCars;
    public int remainingCars;

    public Transform gameScaler;
    public GameObject carPrefab;

    public Car car;

    private GameZoom _zoom;
    private UIManager _uiManager;

    void Start()
    {
        remainingCars = quota;
        finishedCars = 0;
        //_zoom = GameObject.FindObjectOfType<GameZoom>();

        _uiManager = GameObject.FindObjectOfType<UIManager>();

        var dayStart = GameObject.FindObjectOfType<DayStart>();
        dayStart.gameObject.SetActive(true);
        //BeginDay();
;    }

    public void BeginDay()
    {
        _uiManager.Setup(quota, timeInSec, this);
        SpawnCar();
    }

    public void FinishCar()
    {
        if (!car.MarkAsFinished())
        {
            return;
        }

        finishedCars++;
        remainingCars--;

        _uiManager.UpdateProgress();

        if (remainingCars > 0)
        {
            SpawnCar();
        } else
        {
            _uiManager.CompletedDay();
        }
    }

    public void Pause()
    {
        if (car != null)
        {
            car.Pause();
        }
    }

    public void Unpause()
    {
        if (car != null)
        {
            car.Unpause();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        var nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SpawnCar()
    {
        var obj = Instantiate(carPrefab);
        car = obj.GetComponent<Car>();

        car.SetTransitPoints();

        var rect = obj.GetComponent<RectTransform>();

        obj.transform.position = car.carStart.position;
        //rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, car.transitY, 0);
        car.StartTransit();
    }
}
