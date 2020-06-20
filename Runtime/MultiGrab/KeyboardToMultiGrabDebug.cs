using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardToMultiGrabDebug : MonoBehaviour
{
    public KeyCode _input = KeyCode.G;
    public MultiGrab m_grabber;
    public bool m_switchGrabState;
    private void Update()
    {
        if (m_grabber == null) 
            return;
        if (Input.GetKeyDown(_input))
        {
            
            m_switchGrabState = !m_switchGrabState;
            m_grabber.SetGrab(m_switchGrabState);
        }
    }
}
