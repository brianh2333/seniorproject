using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed = 5;
    public float sprint = 1;
    public float sprintDuration = 2;

    Vector2 movementInput;
    Vector2 mousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Magnitude", movementInput.magnitude);

        if (movementInput.x < 0)
        {
            Flip(true);
        }
        else if (movementInput.x > 0)
        {
            Flip(false);
        }

    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //rb.velocity = new Vector2(movementInput.x * moveSpeed, movementInput.y * moveSpeed);
        rb.velocity = movementInput * moveSpeed;
    }

    private void Flip(bool flip)
    {
        GetComponentInChildren<SpriteRenderer>().flipX = flip;
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
