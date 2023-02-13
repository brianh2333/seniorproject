using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private float speedSaved;
    public float lifeTime;
    public int dmg;

    private SpriteRenderer renderer;
    private ParticleSystem particles;

    private bool hitEnemy = false;
    private bool hitObstacle = false;

    // Update is called once per frame

    private void Awake()
    {
        //enabled = true;
        speedSaved = speed;
        renderer = GetComponentInChildren<SpriteRenderer>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (CompareTag("PlayerProjectile"))
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        else if (CompareTag("EnemyProjectile"))
        {
            transform.Translate(speed * Time.deltaTime * GameObject.FindGameObjectWithTag("Player").transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obstacle"))
        {
            hitObstacle = true;
            StartCoroutine(Destroy());

        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            hitEnemy = true;
            collision.gameObject.GetComponent<HealthSystem>().ChangeHealth(dmg, false);
            StartCoroutine(Destroy());
            hitEnemy = false;
        }

    }

    private void OnEnable()
    {
        hitObstacle = false;
        hitEnemy = false;
        speed = speedSaved;
        particles.Stop();
        renderer.enabled = true;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        if (!hitEnemy && !hitObstacle)
            yield return new WaitForSeconds(lifeTime);
        speed = 0;
        renderer.enabled = false;
        particles.Play();
        yield return new WaitForSeconds(.5f);
        particles.Stop();
        gameObject.SetActive(false);

    }

}
