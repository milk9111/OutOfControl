using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public RectTransform progressBar;
    public int width;

    public float timeInSec;
    public float remainingTime;
    public bool paused = true;

    private float _step;

    private Coroutine _timer;

    private UIManager _uiManager;

    private float i;

    public void Setup(float timeLimit, UIManager uiManager)
    {
        progressBar.sizeDelta = new Vector2(width, progressBar.rect.height);

        _uiManager = uiManager;

        timeInSec = timeLimit;
        remainingTime = timeLimit;
        paused = false;

        _step = width / timeLimit;

        _timer = StartCoroutine("TimerCountdown");
    }

    public void Pause()
    {
        paused = true;
        remainingTime = i;
        StopCoroutine(_timer);
    }

    public void Unpause()
    {
        paused = false;
        _timer = StartCoroutine("TimerCountdown");
    }

    private void TimerEnded()
    {
        paused = true;
        _uiManager.TimesUp();
    }

    IEnumerator TimerCountdown()
    {
        for (i = remainingTime; i > 0; i--) {
            yield return new WaitForSeconds(1f);
            progressBar.sizeDelta = new Vector2(progressBar.rect.width - _step, progressBar.rect.height);
        }

        TimerEnded();
    }
}
