using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDouble : MonoBehaviour
{
    public GameObject m_prefab;
    
    public int m_counter = 0;
    public Vector3 m_offsetForSpawn;

    public void SpawnCopy()
    {
        m_counter++;
        SpawnPrefab(m_prefab, m_offsetForSpawn * m_counter);
    }

    void SpawnPrefab(GameObject prefab, Vector3 offset)
    {
        Instantiate(prefab, transform.position + offset, Quaternion.identity);
    }

    public void ResetCpt()
    {
        m_counter = 0;
    }

    void Reset()
    {
        m_prefab = this.gameObject;
    }
}
