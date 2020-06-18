using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGrabKeyboard : MonoBehaviour
{
    public KeyCode _input;
    
    public Grab _grab;
    private void Update()
    {
        if (Input.GetKeyDown(_input))
        {
            _grab.SetGrab();
        }
    }
}
