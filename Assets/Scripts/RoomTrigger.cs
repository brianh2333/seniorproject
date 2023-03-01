using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{

    //All triggers stay active.
    //When player walks into trigger:
    //1. set new room's camera to active.
    //2. set previous room's camera to inactive.
    //How to get new room: 
    //


    [SerializeField]
    private int roomID;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            //InstantiateRoomTriggers.Instance.cameras;
        }
    }

    public void SetRoomID(int id) {
        roomID = id;
    }

    public int GetRoomID() {
        return roomID;
    }

}
