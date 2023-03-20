using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{

    private GameObject camera;


    private void Awake()
    {
        camera = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //Debug.Log("calling RoomTrigger");
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
