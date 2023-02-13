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
    }

    private void OnDisable()
    {
        healthSystem.onHealthChanged -= ChangeHealth;
    }

    void ChangeHealth(float prevHealth, float newHealth, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = newHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
