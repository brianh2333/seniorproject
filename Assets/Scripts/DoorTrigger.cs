using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorUI;

    public float seconds = 3f;

    private float cooldownMax = 5f;
    private float cooldown = 5f;

    private void Awake()
    {
        doorUI = GameObject.FindGameObjectWithTag("DoorUI");
    }

    private void Update()
    {
        if (cooldown <= cooldownMax)
        {
            cooldown += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            doorUI.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            doorUI.SetActive(false);
        }

    }
}
