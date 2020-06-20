using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabbableTag : MonoBehaviour
{
    public static List<GrabbableTag> m_grabbablesInScene = new List<GrabbableTag>();

    public Transform m_whereToGrabIt;
    public Transform m_currentParent;

    public UnityEvent m_onStartGrabbing;
    public UnityEvent m_onReleased;

    void Start()
    {
        m_grabbablesInScene.Add(this);
    }
    void OnDestroy()
    {
        m_grabbablesInScene.Remove(this);
    }

    private void Reset()
    {
        m_whereToGrabIt = transform;
        m_currentParent = transform.parent;
    }

    public Transform GetGrabRoot() { return m_whereToGrabIt; }
    public Transform GetWhereToRelinkAtRelease() { return m_currentParent; }

    public void NotifyStartGrabbing()
    {
        m_onStartGrabbing.Invoke();
    }
    public void NotifyRelease()
    {
        m_onReleased.Invoke();
    }

    internal void RelinkWithWantedParent()
    {
        m_whereToGrabIt.parent = m_currentParent;
    }
}
