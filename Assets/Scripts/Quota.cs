using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quota : MonoBehaviour
{
    public RectTransform progressBar;

    public int total;
    public int current;
    public int width;


    public void Setup(int totalQuota)
    {
        progressBar.sizeDelta = new Vector2(0, progressBar.rect.height);
        total = totalQuota;
        current = 0;
    }

    public void UpdateProgress()
    {
        Debug.Log($"Updating width to: {progressBar.rect.width + width / total}");
        current++;
        progressBar.sizeDelta = new Vector2(progressBar.rect.width + width / total, progressBar.rect.height);
    }
}
