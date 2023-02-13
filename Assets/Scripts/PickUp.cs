using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CompareTag("Collectible"))
            {
                if(name.Contains("HealthOrb"))
                {
                    player.GetComponent<HealthSystem>().ChangeHealth(20, true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
