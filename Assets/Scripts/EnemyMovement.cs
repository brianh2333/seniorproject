using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform shotPosition;

    Rigidbody2D rb;
    public GameObject player;


    Vector2 movement;

    //[SerializeField] private float speed;
    [SerializeField] private float chaseDistance;
    //[SerializeField] private float minDistance;

    [SerializeField] private LayerMask canSee;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        shotPosition = transform.GetChild(0).transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        SetAgentPosition();
    }

    // Update is called once per frame
    void SetAgentPosition()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);


        if (CanSeePlayer(chaseDistance))
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            agent.SetDestination(player.transform.position);
        }

    }

    bool CanSeePlayer(float dist)
    {
        RaycastHit2D hit = Physics2D.Raycast(shotPosition.position, shotPosition.transform.up, dist, canSee);
        

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(shotPosition.position, shotPosition.transform.up * dist, Color.green);
                return true;
            }
            else
                Debug.DrawRay(shotPosition.position, shotPosition.transform.up * dist, Color.blue);
        }
        else
            Debug.DrawRay(shotPosition.position, shotPosition.transform.up * dist, Color.red);

        return false;
    }
}
