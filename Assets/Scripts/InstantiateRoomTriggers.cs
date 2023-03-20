using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRoomTriggers : MonoBehaviour
{
    public static InstantiateRoomTriggers Instance { get; private set; }

    private GameObject[] rooms;
    private GameObject[] doors;

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        //Add triggers to their rooms & doors.
        rooms = GameObject.FindGameObjectsWithTag("Room");
        doors = GameObject.FindGameObjectsWithTag("Door");
        AddTriggers();

    }

    void AddTriggers()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            rooms[i].AddComponent<RoomTrigger>();
            doors[i].AddComponent<DoorTrigger>();
        }
    }
}
