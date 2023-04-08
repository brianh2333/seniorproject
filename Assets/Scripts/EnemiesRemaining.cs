using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesRemaining : MonoBehaviour
{
    //Enemies per room
    [SerializeField] private int enemyCount = 0;
    //Room count
    [SerializeField] private int currRoomIndex = 0;

    public Image prefab;

    public GameObject[] rooms;
    public GameObject[] doors;

    private bool [] roomsActivated;

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
        doors = GameObject.FindGameObjectsWithTag("Door");
        roomsActivated = new bool[rooms.Length];
    }

    public void Remove()
    {
        StartCoroutine(RemoveSkull());
    }

    public void SetUI(Transform room)
    {
        //Debug.Log("Room: " + room.gameObject.name);

        if (roomsActivated[currRoomIndex] == false && room.gameObject == rooms[currRoomIndex])
        {
            roomsActivated[currRoomIndex] = true;
            enemyCount = room.GetChild(1).childCount;
            Debug.Log("enemyCount: " + enemyCount);
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(prefab, transform);
            }
        }
    }

    public void RoomClear()
    {
        //roomsActivated[currRoomIndex] = true;
        FindObjectOfType<AudioManager>().Play("Ding");
        doors[currRoomIndex++].SetActive(false);
        Debug.Log("Room clear");
    }

    //Necessary otherwise the childCount will not update fast enough after a Skull is destroyed.
    IEnumerator RemoveSkull()
    {
        //Debug.Log("Removing " + transform.GetChild(0).gameObject.name);
        Destroy(transform.GetChild(0).gameObject);
        yield return new WaitForSeconds(.1f);
        //Debug.Log("ChildCount: " + transform.childCount);

        if (transform.childCount == 0)
        {
            RoomClear();
        }
    }


}
