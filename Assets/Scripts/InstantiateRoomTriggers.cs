using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRoomTriggers : MonoBehaviour
{
    // public static InstantiateRoomTriggers Instance { get; private set; }

    // public List<Transform> rooms;
    // public List<Transform> triggers;
    // public List<Transform> cameras;

    // static int roomAmount = 0;
    // static int currRoom = 0;

    // void Awake()
    // {
    //     if (Instance != null && Instance != this)
    //         Destroy(this);
    //     else
    //         Instance = this;

    //     //Add rooms, triggers, and cameras to their respective lists
    //     for (int i = 0; i < transform.childCount; i++)
    //     {
    //         Transform t0 = transform.GetChild(i);
    //         rooms.Add(t0);
    //         Transform t1 = t0.GetChild(0);
    //         triggers.Add(t1);
    //         Transform t2 = t0.GetChild(1);
    //         cameras.Add(t2);
    //         roomAmount++;
    //     }

    //     AddTriggers();

    // }

    // void AddTriggers() {
    //     for (int i = 0; i < rooms.Length; i++) {
    //         rooms[i].gameObject.AddComponent<RoomTrigger>() as RoomTrigger;
    //         RoomTrigger.SetRoomID(i + 1);
    //     }
    // }
}
