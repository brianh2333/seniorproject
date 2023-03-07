using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesRemaining : MonoBehaviour
{
//Start at -1 because we need the last index
    private int enemyIndex = -1;
    //Room count
    private int currRoomIndex = 0;

    public Image prefab;

    public GameObject[] rooms;

    private bool [] roomsCleared;

    public static EnemiesRemaining Instance { get; private set; }

    private void Start()
    {
        if (Instance != this || Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    void Awake()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");
        roomsCleared = new bool[rooms.Length];
        //SetUI(rooms[0].transform);
    }

    public void Remove()
    {
        Debug.Log("Removing");
        transform.GetChild(enemyIndex--).gameObject.SetActive(false);
    }

    public void SetUI(Transform room)
    {
        Debug.Log("Room: " + room.gameObject.name);
        // if (transform.childCount > 0)
        // {
        //     for (int i = 0; i < transform.childCount; i++)
        //     {
        //         Destroy(transform.GetChild(i).gameObject);
        //     }
        // }


        enemyIndex = room.GetChild(1).childCount;
        Debug.Log("enemyIndex: " + enemyIndex);
        for (int i = 0; i < enemyIndex; i++)
        {
            Instantiate(prefab, transform);
        }
    }


}
