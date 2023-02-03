using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDroneInGameZoneMono : MonoBehaviour
{
    public GameObject m_dronePrefab;
    public List<DroneInGame> m_droneCreated = new List<DroneInGame>();

    [System.Serializable]
    public class DroneInGame {
        public int m_index;
        public bool m_isActive;
        public Vector3 m_position;
        public Quaternion m_rotation;
        public GameObject m_createdDrone;
    }


    [ContextMenu("Create Drone")]
    public void CreateDrone() {

        GameObject g = GameObject.Instantiate(m_dronePrefab);
        DroneInGame d = new DroneInGame() { m_createdDrone = g };
        d.m_index = m_droneCreated.Count;
        m_droneCreated.Add(d); 
    }


    void Update()
    {
        foreach (var item in m_droneCreated)
        {
            item.m_createdDrone.transform.position = item.m_position;
            item.m_createdDrone.transform.rotation = item.m_rotation;
            if(item.m_createdDrone.activeSelf != item.m_isActive){
                item.m_createdDrone.SetActive(item.m_isActive);
            }


        }
    }
}
