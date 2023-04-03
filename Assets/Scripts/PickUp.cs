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
                FindObjectOfType<AudioManager>().Play("Powerup");
                if(name.Contains("HealthOrb"))
                {
                    player.GetComponent<HealthSystem>().ChangeHealth(20, true);
                    Destroy(gameObject);
                }
                if (name.Contains("GoldKnife"))
                {
                    player.GetComponent<FireProjectile>().AddPowerUpAmmo();
                    Destroy(gameObject);
                }
                if (name.Contains("SpeedBoost"))
                {
                    player.GetComponent<PlayerController>().StartSprint();
                    Destroy(gameObject);
                }
                if (name.Contains("Armor")) {
                    player.GetComponent<HealthSystem>().IncreaseHealth(10);
                    Destroy(gameObject);
                }
            }
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
