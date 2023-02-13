using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;


    Vector2 movement;

    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Move();
    }

    // Update is called once per frame
    void Move()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);


        if (distance > 2f && distance < chaseDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }
}
