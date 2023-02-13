using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireProjectile : MonoBehaviour
{
    public Transform shotPosition;

    public GameObject prefab;
    public GameObject player;

    private int ammoIndex;

    public float reloadMaxTime;
    public float maxAmmo;
    public float fireRate;
    private float fireRateSeconds = 0;
    private float reloadTime;
    private float ammo;

    [SerializeField] private float distance = 1f;

    [SerializeField] private LayerMask canHit;

    private void Awake()
    {
        reloadTime = reloadMaxTime;
        ammo = maxAmmo;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        Vector3 diff = player.transform.position - shotPosition.transform.position;
        diff.Normalize();

        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        shotPosition.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);

    }

    void Update()
    {
        if (CanSeePlayer(distance))
        {
            if (ammo == 0)
            {
                reloadTime -= Time.deltaTime;
                if (reloadTime <= 0)
                {
                    reloadTime = reloadMaxTime;
                    ammo = maxAmmo;
                    ammoIndex++;
                }

            }


            if (fireRateSeconds <= 0)
            {
                if (ammo > 0)
                {
                    Vector3 pos = new Vector3(shotPosition.position.x, shotPosition.position.y, 0);
                    Instantiate(prefab, pos, shotPosition.rotation);
                    fireRateSeconds = fireRate;
                    ammo--;
                    ammoIndex--;
                }
            }
            else
                fireRateSeconds -= Time.deltaTime;
        }


    }

    bool CanSeePlayer(float dist)
    {
        RaycastHit2D hit = Physics2D.Raycast(shotPosition.position, shotPosition.transform.up, dist, canHit);
        Debug.DrawRay(shotPosition.position, shotPosition.transform.up * dist, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }


}
