using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MultiGrab : MonoBehaviour
{

    public Transform m_grabber;
    public Transform m_grabbedStorageParent;
    public LayerMask m_grabbableLayer;
    public float m_radius=0.1f;

   

    Vector3 m_previousPosition;
    Quaternion m_previousRotation;

    [Header("Debug Struct, DONT TOUCH")]
    [SerializeField]
    GrabbableTag[] m_grabbed;
    bool grabbing = false;

    public UnityEvent m_goingToGrab;
    public UnityEvent m_goingToRelease;



    private void Reset()
    {
        m_grabber = gameObject.transform;
        m_grabbedStorageParent = gameObject.transform;
    }


    public void GrabItem()
    {
        m_goingToGrab.Invoke();
        m_grabbed = GetGrabbableInZone();
        
        for (int i = 0; i < m_grabbed.Length; i++)
        {
            ApplyGrabbing(m_grabbed[i]);
        }
    }

    private void ApplyGrabbing(GrabbableTag grabbableTag)
    {
        grabbableTag.GetGrabRoot().parent = m_grabbedStorageParent;
        grabbableTag.NotifyStartGrabbing();
    }
    private void ApplyReleased(GrabbableTag grabbableTag)
    {
        grabbableTag.RelinkWithWantedParent();
        grabbableTag.NotifyRelease();
    }


    private GrabbableTag[] GetGrabbableInZone()
    {
      Collider [] touched =  Physics.OverlapSphere(m_grabber.position, m_radius, m_grabbableLayer, QueryTriggerInteraction.Ignore);      
      return touched
            .Where(k => k.GetComponent<GrabbableTag>() != null)
            .Select(k=>k.GetComponent<GrabbableTag>()).ToArray();
    }

    public void ReleaseGrabItem()
    {
        m_goingToRelease.Invoke();
        for (int i = 0; i < m_grabbed.Length; i++)
        {
            ApplyReleased(m_grabbed[i]);
        }
    }


    public void SetGrab(bool pressing = true)
    {
        grabbing = pressing;
        if (grabbing)
        {
            GrabItem();
        }
        else
        {
            ReleaseGrabItem();
        }
    }

    public void SetRadius(float radius)
    {
        m_radius = radius;
    }

}
