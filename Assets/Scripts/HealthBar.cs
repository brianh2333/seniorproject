using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthSystem healthSystem;

    public Slider slider;

    public Gradient gradient;

    public Image fill;


    private void Awake()
    {
        fill.color = gradient.Evaluate(1f);
        healthSystem.onHealthChanged += ChangeHealth;
        healthSystem.onHealthIncreased += ChangeHealth;
    }

    private void OnDisable()
    {
        healthSystem.onHealthChanged -= ChangeHealth;
        healthSystem.onHealthIncreased -= ChangeHealth;
    }

    void ChangeHealth(float amount)
    {
        Debug.Log("Changing health by " + amount);
        slider.maxValue += amount;
        slider.value += amount;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void ChangeHealth(float newHealth, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = newHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
