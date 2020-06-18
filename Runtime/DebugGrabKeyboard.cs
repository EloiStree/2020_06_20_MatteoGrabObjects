using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGrabKeyboard : MonoBehaviour
{
    public KeyCode _input;
    
    public Grab _grab;
    bool _current = false;
    private void Update()
    {
        if (Input.GetKeyDown(_input))
        {
            _current = !_current;
            if (_current)
                _grab.SetGrab();
        }
    }
}
