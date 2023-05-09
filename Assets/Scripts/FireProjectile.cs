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
    private int ammoMax;
    private int ammo;

    [SerializeField]
    private int powerUpAmmoMax;
    private int powerUpAmmo;
    private int powerUpAmmoIndex;

    public float reloadMaxTime;
    public float fireRate;
    private float fireRateSeconds = 0;
    private float reloadTime;

    public GameObject gKnife;
    public GameObject knife;

    private void Awake()
    {
        ammoMax = 10;//ProjectilePooler.Instance.GetPoolSize("Knife");
        ammo = ammoMax - 1;

        powerUpAmmoMax = 3;//ProjectilePooler.Instance.GetPoolSize("GoldKnife");
        powerUpAmmo = 0;
        powerUpAmmoIndex = 0;

        reloadTime = reloadMaxTime;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (ammo < (ammoMax - 1))
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
            if (Input.GetMouseButtonDown(0) && powerUpAmmo > 0)
            {
                FindObjectOfType<AudioManager>().Play("KnifeThrow");
                powerUpAmmo--;
                Vector3 pos = new Vector3(shotPosition.position.x, shotPosition.position.y, 0);
                Instantiate(gKnife, pos, shotPosition.rotation);
                fireRateSeconds = fireRate;
                powerUpAmmoUI[powerUpAmmoIndex--].SetActive(false);
            }
            else if (Input.GetMouseButtonDown(0) && ammo >= 0)
            {
                FindObjectOfType<AudioManager>().Play("KnifeThrow");
                Vector3 pos = new Vector3(shotPosition.position.x, shotPosition.position.y, 0);
                Instantiate(knife, pos, shotPosition.rotation);
                fireRateSeconds = fireRate;
                ammoUI[ammo--].SetActive(false);
            }
        }
        else
            fireRateSeconds -= Time.deltaTime;

    }

    public void AddPowerUpAmmo()
    {
        powerUpAmmo = powerUpAmmoMax;
        powerUpAmmoIndex = powerUpAmmoMax - 1;

        for (int i = 0; i < powerUpAmmoMax; i++)
            powerUpAmmoUI[i].SetActive(true);
    }

}
