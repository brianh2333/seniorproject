using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public HealthSystem healthSystem;

    public Color low;
    public Color high;

    public Slider slider;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        healthSystem = GetComponentInParent<HealthSystem>();
        healthSystem.onHealthChanged += ChangeHealth;
        //gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        healthSystem.onHealthChanged -= ChangeHealth;
    }

    private void OnEnable()
    {
        healthSystem.onHealthChanged += ChangeHealth;
    }

    void ChangeHealth(float newHealth, float prevHealth, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = newHealth;
        slider.gameObject.SetActive(newHealth < maxHealth);

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }


    void Update()
    {
        transform.position = transform.parent.position + offset;
    }
}
