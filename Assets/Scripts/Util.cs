using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util 
{
    public static GlobalConfig GetGlobalConfig()
    {
        return GameObject.FindGameObjectWithTag("GlobalConfig").GetComponent<GlobalConfig>();
    }

    public static SoundManager GetSoundManager()
    {
        return GameObject.FindObjectOfType<SoundManager>();
    }
}
