using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireProjectile : MonoBehaviour
{
    public Transform shotPosition;

    public ProjectilePooler projPooler;

    public List<GameObject> ammoUI;

    public int maxAmmo;
    private int ammo;

    public float reloadMaxTime;
    public float fireRate;
    private float fireRateSeconds = 0;
    private float reloadTime;

    private void Awake()
    {
        reloadTime = reloadMaxTime;
        ammo = maxAmmo - 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (ammo < (maxAmmo - 1))
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                reloadTime = reloadMaxTime;
                ammoUI[++ammo].SetActive(true);
            }

        }


        if (fireRateSeconds <= 0)
        {
            if (Input.GetMouseButtonDown(0) && ammo >= 0)
            {
                Vector3 pos = new Vector3(shotPosition.position.x, shotPosition.position.y, 0);
                projPooler.SpawnFromPool("Knife", pos, shotPosition.rotation);
                fireRateSeconds = fireRate;
                ammoUI[ammo--].SetActive(false);
            }
        }
        else
            fireRateSeconds -= Time.deltaTime;

    }

}
