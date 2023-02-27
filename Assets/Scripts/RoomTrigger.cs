using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public List<Transform> rooms;
    public List<Transform> triggers;
    public List<Transform> cameras;
    void Awake()
    {
        //Add rooms, triggers, and cameras to their respective lists
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t0 = transform.GetChild(i);
            rooms.Add(t0);
            Transform t1 = t0.GetChild(0);
            triggers.Add(t1);
            Transform t2 = t0.GetChild(1);
            cameras.Add(t2);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
