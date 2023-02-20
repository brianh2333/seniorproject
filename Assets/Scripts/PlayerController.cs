using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed = 5;
    public float sprint = 1;
    public float sprintDuration = 2;

    Vector2 moveDirection;
    Vector2 mousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        ProcessInputs();

        animator.SetFloat("Magnitude", moveDirection.magnitude);

        if (moveDirection.x < 0)
        {
            Flip(true);
        }
        else if (moveDirection.x > 0)
        {
            Flip(false);
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Flip(bool flip)
    {
        GetComponentInChildren<SpriteRenderer>().flipX = flip;
    }

    private void ProcessInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }

    public void StartSprint()
    {
        StartCoroutine(Sprint());
    }
    private IEnumerator Sprint()
    {
        Debug.Log("Sprint start");
        moveSpeed += sprint;
        yield return new WaitForSeconds(sprintDuration);
        moveSpeed -= sprint;
        Debug.Log("Sprint end");
    }

}
