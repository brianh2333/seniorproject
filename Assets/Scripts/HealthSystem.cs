using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public delegate void OnHealthChanged(float  prevHealth, float health, float maxHealth);
    public event OnHealthChanged onHealthChanged = delegate { };


    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public bool isPlayer = false;


    void Awake()
    {
        health = maxHealth;
        onHealthChanged(maxHealth, maxHealth, maxHealth);
    }

    private void Update()
    {
        if (health <= 0 && isPlayer)
        {
            SceneManager.LoadScene("Level1");
        }
        if (health <= 0 && !isPlayer)
        {
            Despawn();
        }
    }

    public void ChangeHealth(int amount, bool heal)
    {
        if (heal)
        {
            if (health < maxHealth)
            {
                float prevHealth = health;
                if (amount > maxHealth)
                {
                    health = maxHealth;
                }
                else
                    health += amount;
                health = Mathf.Clamp(health, 0, maxHealth);
                onHealthChanged(prevHealth, health, maxHealth);
            }
        }
        else
        {
            if (health > 0)
            {
                float prevHealth = health;
                if (amount > health)
                {
                    health = 0;
                }
                else
                    health -= amount;
                health = Mathf.Clamp(health, 0, maxHealth);
                onHealthChanged(prevHealth, health, maxHealth);
                Debug.Log("Taking dmg: " + amount);
            }
        }

    }

    private void Despawn()
    {
        gameObject.SetActive(false);
    }
}
