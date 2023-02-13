using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireProjectile : MonoBehaviour
{
    public Transform shotPosition;

    public ProjectilePooler projPooler;

    public Text ammoUI;

    private int ammoIndex;

    public float maxAmmo;
    public float reloadMaxTime;
    public float fireRate;
    private float fireRateSeconds = 0;
    private float ammo;
    private float reloadTime;

    private void Awake()
    {
        reloadTime = reloadMaxTime;
        ammo = maxAmmo;
        ammoUI.text = maxAmmo + " / " + maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        if (ammo == 0)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                reloadTime = reloadMaxTime;
                ammo = maxAmmo;
                ammoIndex++;
                ammoUI.text = maxAmmo + " / " + maxAmmo;
                //ammoUI[ammoIndex].SetActive(true);
            }

        }


        if (fireRateSeconds <= 0)
        {
            if (Input.GetMouseButtonDown(0) && ammo > 0)
            {
                Vector3 pos = new Vector3(shotPosition.position.x, shotPosition.position.y, 0);
                projPooler.SpawnFromPool("Knife", pos, shotPosition.rotation);
                fireRateSeconds = fireRate;
                ammo--;
                ammoUI.text = ammo + " / " + maxAmmo;
                //ammoUI[ammoIndex].SetActive(false);
                ammoIndex--;
            }
        }
        else
            fireRateSeconds -= Time.deltaTime;

    }

}
