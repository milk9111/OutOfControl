using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZoom : MonoBehaviour
{
    public float max;
    public float min;
    public float dragSpeed = 2;
    public float zoomSpeed = 100;

    private bool _isDragging;

    private Vector3 _dragOrigin;

    private Vector3 _startPosition;

    void Start()
    {
        _isDragging = false;
        _startPosition = transform.position;
    }

    void Update()
    {
        var input = Input.mouseScrollDelta.y;
        if (Mathf.Abs(input) > 0.05f)
        {
            transform.localScale = new Vector3(MinMax(transform.localScale.x + input), MinMax(transform.localScale.y + input), transform.localScale.z);

            Vector3 pos = transform.parent.position;
            if (input > 0)
            {
                pos = Input.mousePosition;
            }

            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * zoomSpeed);
        }

        if (FullyZoomedOut())
        {
            return;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isDragging = false;
        }

        if (Input.GetMouseButton(1) && !_isDragging)
        {
            _isDragging = true;
            _dragOrigin = Input.mousePosition;
            return;
        }

        if (_isDragging)
        {
            var pos = Input.mousePosition;
            var diff = new Vector3(pos.x - _dragOrigin.x, pos.y - _dragOrigin.y, 0);

            Debug.Log("Drag Origin: " + _dragOrigin);
            Debug.Log("pos: " + pos);
            Debug.Log("diff: " + diff);

            var target = new Vector3(transform.position.x + diff.x, transform.position.y + diff.y, 0);

            //Debug.Log("Start: " + transform.position);
            //Debug.Log("Target: " + target);
            transform.position = Vector3.MoveTowards(transform.position, target, dragSpeed * Time.deltaTime);
        }
    }

    public void ResetZoom()
    {
        transform.localScale = Vector3.one;
        transform.position = _startPosition;
    }

    private float MinMax(float input)
    {
        return Mathf.Max(Mathf.Min(input, max), min);
    }

    private bool FullyZoomedOut()
    {
        return transform.localScale.x == min && transform.localScale.y == min && transform.localScale.z == min;
    }
}
