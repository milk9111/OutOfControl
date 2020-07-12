using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenAdjuster : MonoBehaviour
{
    private Canvas _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = GetComponent<Canvas>();

        RectTransform rt = GetComponent<RectTransform>();

        float canvasHeight = rt.rect.height;
        float canvasWidth = rt.rect.width;

        float desiredCanvasWidth = canvasHeight * Camera.main.aspect;
        float desiredCanvasHeight = canvasWidth * Camera.main.aspect;

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredCanvasWidth);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, desiredCanvasHeight);
    }
}
