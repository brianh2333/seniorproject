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

    [SerializeField] private float velocity;

    [SerializeField] private float maxSpeed = 0.3f;

    private void Awake()
    {
        healthSystem = GetComponentInParent<HealthSystem>();
        SetHealth(healthSystem.GetMaxHealth());
        //healthSystem.onHealthChanged += ChangeHealth;
    }


    void Update() {

        transform.position = transform.parent.position + offset;

        if (slider.value != healthSystem.GetHealth()) {

            slider.value = Mathf.SmoothDamp(slider.value, healthSystem.GetHealth(), ref velocity, maxSpeed);
            slider.gameObject.SetActive(true);
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
        }
    }

    private void OnDisable()
    {
        //healthSystem.onHealthChanged -= ChangeHealth;
    }

    void SetHealth(float maxHealth)
    {
        //Debug.Log("Calling ChangeHealth");
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

}
