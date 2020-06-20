using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereToMultiGrabRadius : MonoBehaviour
{
    public MultiGrab m_multiGrab;
    public Transform m_sphereScale;
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
        if (m_multiGrab != null && m_sphereScale != null)
        {
            float maxDistance = m_sphereScale.lossyScale.x;
            if (maxDistance < m_sphereScale.lossyScale.y)
                maxDistance = m_sphereScale.lossyScale.y;
            if (maxDistance < m_sphereScale.lossyScale.z)
                maxDistance = m_sphereScale.lossyScale.z;


             m_multiGrab.SetRadius(maxDistance);
        }
    }
    private void OnValidate()
    {
        RefreshRadius();
    }
}
