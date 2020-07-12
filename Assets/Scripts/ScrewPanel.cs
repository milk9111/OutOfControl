using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewPanel : MonoBehaviour
{
    public IList<ScrewHole> screwHoles;

    public bool finishedPanel;

    // Start is called before the first frame update
    void Start()
    {
        finishedPanel = false;
        screwHoles = GetComponentsInChildren<ScrewHole>();
    }


    public bool MarkAsFinished()
    {
        if (!finishedPanel && !AreScrewsHoleDone())
        {
            return false;
        }

        finishedPanel = true;
        return true;
    }

    private bool AreScrewsHoleDone()
    {
        var done = true;
        foreach(var screwHole in screwHoles)
        {
            done = done && screwHole.IsScrewFinished();
        }

        return done;
    }

    public void Pause()
    {
        foreach (var screwHole in screwHoles)
        {
            screwHole.Pause();
        }
    }

    public void Unpause()
    {
        foreach (var screwHole in screwHoles)
        {
            screwHole.Unpause();
        }
    }
}
