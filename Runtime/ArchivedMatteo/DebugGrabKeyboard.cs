using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGrabKeyboard : MonoBehaviour
{
    public KeyCode _input;
    
    public Grab _grab;
    public bool m_switchGrabState;
    private void Update()
    {
        if (Input.GetKeyDown(_input))
        {
            m_switchGrabState =! m_switchGrabState;
            _grab.SetGrab(m_switchGrabState);
        }
    }
}
