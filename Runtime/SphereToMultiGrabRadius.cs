using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereToMultiGrabRadius : MonoBehaviour
{
    public MultiGrab m_multiGrab;
    public SphereCollider m_sphereCollider;
    public bool m_refeshRadiusInStart;
    public bool m_refeshRadiusInUpdate;
    void Start()
    {
        if (m_refeshRadiusInStart)
            RefreshRadius();
    }


    void Update()
    {
        if(m_refeshRadiusInUpdate)
            RefreshRadius();


    }
    private void RefreshRadius()
    {
        if(m_multiGrab!=null  && m_sphereCollider!=null )
             m_multiGrab.SetRadius(m_sphereCollider.radius);
    }
    private void OnValidate()
    {
        RefreshRadius();
    }
}
