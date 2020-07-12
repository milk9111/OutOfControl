using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewHole : MonoBehaviour
{
    public GameObject screwPrefab;

    public bool paused;

    public Screw screw;

    private CursorControls _cursorControls;

    private Collider2D _collider;

    void Start()
    {
        paused = false;
        screw = null;

        _cursorControls = GameObject.FindObjectOfType<CursorControls>();

        _collider = GetComponent<Collider2D>();
    }

    public void PlaceScrew()
    {
        if (paused || screw != null)
        {
            return;
        }

        _collider.enabled = false;

        _cursorControls.MouseExit();

        var obj = Instantiate(screwPrefab, transform);
        screw = obj.GetComponent<Screw>();

        var sounds = Util.GetSoundManager();
        screw.screwSound = sounds.screwSound;
        screw.screwDoneSound = sounds.screwDoneSound;
    }

    public bool IsScrewFinished()
    {
        return screw != null && screw.currentTurn == screw.turnsUntilDone;
    }

    void OnMouseDown()
    {
        PlaceScrew();
    }

    void OnMouseEnter()
    {
        if (paused || screw != null)
        {
            return;
        }

        _cursorControls.MouseEnter();
    }

    void OnMouseExit()
    {
        if (paused || screw != null)
        {
            return;
        }

        _cursorControls.MouseExit();
    }

    public void Pause()
    {
        paused = true;
        if (screw != null)
        {
            screw.Pause();
        }
    }

    public void Unpause()
    {
        paused = false;
        if (screw != null)
        {
            screw.Unpause();
        }
    }
}
