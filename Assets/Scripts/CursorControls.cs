using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControls : MonoBehaviour
{
    private GlobalConfig _config;

    void Awake()
    {
        _config = Util.GetGlobalConfig();
        Cursor.SetCursor(_config.defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void MouseEnter()
    {
        Cursor.SetCursor(_config.highlightCursor, Vector2.zero, CursorMode.Auto);
    }

    public void MouseExit()
    {
        Cursor.SetCursor(_config.defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
