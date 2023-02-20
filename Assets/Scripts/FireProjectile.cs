using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireProjectile : MonoBehaviour
{
    public Transform shotPosition;

    public ProjectilePooler projPooler;

    public List<GameObject> ammoUI;
    public List<GameObject> powerUpAmmoUI;

    [SerializeField]
    private int maxAmmo;
    private int ammo;

    [SerializeField]
    private int powerUpMaxAmmo;
    private int powerUpAmmo;

    public float reloadMaxTime;
    public float fireRate;
    private float fireRateSeconds = 0;
    private float reloadTime;

    private void Awake()
    {
        maxAmmo = 10;//ProjectilePooler.Instance.GetPoolSize("Knife");
        ammo = maxAmmo - 1;

        powerUpMaxAmmo = 3;//ProjectilePooler.Instance.GetPoolSize("GoldKnife");
        powerUpAmmo = 0;

        reloadTime = reloadMaxTime;
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
            if (Input.GetMouseButtonDown(0) && powerUpAmmo >= 0)
            {
                Vector3 pos = new Vector3(shotPosition.position.x, shotPosition.position.y, 0);
                projPooler.SpawnFromPool("GoldKnife", pos, shotPosition.rotation);
                fireRateSeconds = fireRate;
                powerUpAmmoUI[powerUpAmmo--].SetActive(false);
            }
            else if (Input.GetMouseButtonDown(0) && ammo >= 0)
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

    public void AddPowerUpAmmo()
    {
        powerUpAmmo = powerUpMaxAmmo - 1;

        for (int i = 0; i < powerUpMaxAmmo; i++)
            powerUpAmmoUI[i].SetActive(true);
    }

}
