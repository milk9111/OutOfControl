using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Screw : MonoBehaviour
{
    public int turnsUntilDone;
    public int currentTurn;

    public bool paused;

    public AudioSource screwSound;
    public AudioSource screwDoneSound;

    private Animator _animator;

    private GlobalConfig _config;

    private CursorControls _cursorControls;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        _config = Util.GetGlobalConfig();

        _animator = GetComponent<Animator>();
        currentTurn = 0;

        _cursorControls = GameObject.FindObjectOfType<CursorControls>();
    }

    public void StartTurn()
    {
        if (paused)
        {
            return;
        }

        if (currentTurn >= turnsUntilDone) {
            screwDoneSound.Play();
            Debug.Log("Reached max turns!");
            return;
        }

        screwSound.Play();
        _animator.Play("Spin2");

        currentTurn++;
    }

    void OnMouseDown()
    {
        StartTurn();
    }

    void OnMouseEnter()
    {
        if (paused)
        {
            return;
        }

        _cursorControls.MouseEnter();
    }

    void OnMouseExit()
    {
        if (paused)
        {
            return;
        }

        _cursorControls.MouseExit();
    }

    public void Pause()
    {
        paused = true;
    }

    public void Unpause()
    {
        paused = false;
    }
}
