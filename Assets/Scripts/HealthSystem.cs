using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{


    public delegate void OnHealthChanged(float health, float maxHealth);
    public event OnHealthChanged onHealthChanged = delegate { };

    public delegate void OnHealthIncreased(float health);
    public event OnHealthIncreased onHealthIncreased = delegate { };


    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public bool isPlayer = false;


    void Start()
    {
        health = maxHealth;
        onHealthChanged(maxHealth, maxHealth);
    }

    void onEnable() {
        onHealthIncreased += IncreaseHealth;
    }

    void onDisable() {
        onHealthIncreased -= IncreaseHealth;
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
                onHealthChanged(health, maxHealth);
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
                onHealthChanged(health, maxHealth);
                //Debug.Log("Taking dmg: " + amount);
            }
        }

    }

    public void IncreaseHealth(float amount) {
        maxHealth += amount;
        health = maxHealth;
        onHealthIncreased(amount);
    }

    private void Despawn()
    {
        gameObject.SetActive(false);
    }

    public float GetMaxHealth() {
        return maxHealth;
    }
}
