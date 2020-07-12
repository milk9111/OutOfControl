using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool hasScrewSelected;

    // Start is called before the first frame update
    void Start()
    {
        hasScrewSelected = false;
    }

    public void SelectScrew()
    {
        hasScrewSelected = true;
    }

    public void DeselectScrew()
    {
        hasScrewSelected = false;
    }
}
