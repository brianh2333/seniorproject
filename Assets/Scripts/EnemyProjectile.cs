using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int dmg;

    private SpriteRenderer renderer;
    private ParticleSystem particles;
    private Rigidbody2D rb;
    public GameObject player;

    private bool hitPlayer = false;
    private bool hitObstacle = false;

    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        particles = GetComponentInChildren<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
            Destroy(gameObject);

        Vector2 moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        hitObstacle = false;
        hitPlayer = false;
        particles.Stop();
        renderer.enabled = true;
        StartCoroutine(Destroy());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obstacle"))
        {
            hitObstacle = true;
            StartCoroutine(Destroy());

        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            hitPlayer = true;
            collision.gameObject.GetComponent<HealthSystem>().ChangeHealth(dmg, false);
            StartCoroutine(Destroy());
            hitPlayer = false;
        }

    }

    IEnumerator Destroy()
    {
        if (!hitPlayer && !hitObstacle)
            yield return new WaitForSeconds(lifeTime);
        renderer.enabled = false;
        particles.Play();   
        yield return new WaitForSeconds(.5f);
        particles.Stop();
        Destroy(gameObject);

    }
}
