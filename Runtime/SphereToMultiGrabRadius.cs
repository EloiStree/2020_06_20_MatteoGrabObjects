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
            float maxDistance = m_sphereScale.lossyScale.x/2f;
            if (maxDistance < m_sphereScale.lossyScale.y / 2f)
                maxDistance = m_sphereScale.lossyScale.y / 2f;
            if (maxDistance < m_sphereScale.lossyScale.z / 2f)
                maxDistance = m_sphereScale.lossyScale.z / 2f;


             m_multiGrab.SetRadius(maxDistance);
        }
    }
    private void OnValidate()
    {
        RefreshRadius();
    }
}
