using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform shotPosition;

    Rigidbody2D rb;
    public GameObject player;


    Vector2 movement;

    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;

    [SerializeField] private LayerMask canSee;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        shotPosition = transform.GetChild(0).transform;
    }

    private void Update()
    {
        Move();
    }

    // Update is called once per frame
    void Move()
    {
        //float distance = Vector2.Distance(transform.position, player.transform.position);


        if (CanSeePlayer(chaseDistance))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

    bool CanSeePlayer(float dist)
    {
        RaycastHit2D hit = Physics2D.Raycast(shotPosition.position, shotPosition.transform.up, dist, canSee);
        Debug.DrawRay(shotPosition.position, shotPosition.transform.up * dist, Color.blue);

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
