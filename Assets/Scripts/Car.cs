using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float transitSpeed = 10;

    public float transitY;

    public IList<ScrewPanel> panels;

    public bool finishedCar;

    public bool inTransit;
    public bool toMiddle = false;

    public bool paused;

    public Transform carStart;
    public Transform carMiddle;
    public Transform carEnd;

    private RectTransform _rect;
    private Vector3 _target;

    private float _startX;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    void Update()
    {
        if (paused)
        {
            return;
        }

        if (_target != null && transform.position.x == _target.x && transform.position.y == _target.y)
        {
            EndTransit();
        }

        if (!inTransit)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, transitSpeed * Time.deltaTime);
    }

    public void StartTransit()
    {
        if (_rect == null)
        {
            Setup();
        }

        toMiddle = !toMiddle;

        _target = carMiddle.position;
        if (!toMiddle)
        {
            _target = carEnd.position;
        }
        inTransit = true;
    }

    public void EndTransit()
    {
        if (!toMiddle)
        {
            Destroy(gameObject);
        }

        inTransit = false;
    }

    public void Pause()
    {
        paused = true;
        foreach(var panel in panels)
        {
            panel.Pause();
        }
    }

    public void Unpause()
    {
        paused = false;
        foreach(var panel in panels)
        {
            panel.Unpause();
        }
    }

    public bool MarkAsFinished()
    {
        if (!ArePanelsDone())
        {
            return false;
        }

        finishedCar = true;
        StartTransit();
        return true;
    }

    private bool ArePanelsDone()
    {
        foreach(var panel in panels)
        {
            if (!panel.MarkAsFinished())
            {
                return false;
            }
        }

        return true;
    }

    public void SetTransitPoints()
    {
        carStart = GameObject.FindGameObjectWithTag("CarStart").GetComponent<Transform>();
        carMiddle = GameObject.FindGameObjectWithTag("CarMiddle").GetComponent<Transform>();
        carEnd = GameObject.FindGameObjectWithTag("CarEnd").GetComponent<Transform>();
    }

    private void Setup()
    {
        SetTransitPoints();

        finishedCar = false;
        paused = false;
        panels = GetComponentsInChildren<ScrewPanel>();

        _rect = GetComponent<RectTransform>();
        _startX = transform.position.x;
    }
}
