using System.Collections;
using System.Collections.Generic;
//using Regex;
using System.Text.RegularExpressions;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{

    private GameObject camera;



    private void Awake()
    {
        camera = transform.GetChild(0).gameObject;
        //GameManager.SetRoomText("Room " + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //int currRoom = camera.transform.parent.name;
            //GameManager.SetRoomText("Room " + currRoom);
            camera.SetActive(true);
            EnemiesRemaining.Instance.SetUI(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            camera.SetActive(false);
        }
    }

}
