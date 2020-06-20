using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THE BEST SOLUTION WOULD BE TO COMPUTE THE MOMENTOM HERE AND TO APPLY A MOMENTOM SCRIPT AFTER
//BUT FOR NOW  I WILL APPLY A FORCE
public class TransformToVelocityKeeper : MonoBehaviour
{
    public Transform m_toObserve;
    public Rigidbody m_toApplyOn;
    public float m_forceByDeltaMove=1;
    public float m_forceMultiplictorRotation=1;

    public Vector3 m_forceCumulated = Vector3.forward;
    public ForceMode m_moveForce = ForceMode.Impulse;
    public bool m_useRotation;
    public Vector3 m_rotationForceCumulated = new Vector3(-90,0,0);
    public ForceMode m_rotateForce = ForceMode.Impulse;

    public bool m_recordForce;
    public void StartRecordingForce() {
        m_recordForce = true;
    }

    public void ApplyCumulatedForce()
    {
        m_recordForce = false;
        m_toApplyOn.AddForce(m_forceCumulated, m_moveForce);

        m_toApplyOn.AddTorque(m_toObserve.right *
            m_forceMultiplictorRotation *
            m_rotationForceCumulated.x, m_rotateForce);
        m_toApplyOn.AddTorque(m_toObserve.forward *
            m_forceMultiplictorRotation *
            m_rotationForceCumulated.z, m_rotateForce);
        m_toApplyOn.AddTorque(m_toObserve.up *
            m_forceMultiplictorRotation *
            m_rotationForceCumulated.y, m_rotateForce);
    }
    public Vector3 euleurDelta;
    private void Update()
    {
        if (!m_recordForce)
            return;
        Vector3 delta = m_toObserve.position - m_previousPosition;
        m_forceCumulated += delta * m_forceByDeltaMove;

        if (m_useRotation)
        {
            Quaternion deltaRotation = m_toObserve.rotation *Quaternion.Inverse(m_previousRotation);
             euleurDelta = deltaRotation.eulerAngles;
            if (euleurDelta.x > 180f) euleurDelta.x = (euleurDelta.x - 360f);
            if (euleurDelta.y > 180f) euleurDelta.y =  (euleurDelta.y - 360f);
            if (euleurDelta.z > 180f) euleurDelta.z =  (euleurDelta.z - 360f);
            m_rotationForceCumulated += euleurDelta;
           // throw new System.NotImplementedException();
        }


        m_previousPosition = m_toObserve.position;
        m_previousRotation = m_toObserve.rotation;
        m_previousDirection = m_toObserve.forward;
        
    }
    Vector3    m_previousPosition;
    Quaternion m_previousRotation;
    Vector3    m_previousDirection;

    private void Reset()
    {
        m_toApplyOn = GetComponent<Rigidbody>();
        m_toObserve = transform;
    }
}
