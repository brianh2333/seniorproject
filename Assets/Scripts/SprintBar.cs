using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public HealthSystem healthSystem;

    public Slider slider;

    public Image fill;

    bool canRegen = false;


    private void Awake()
    {
        healthSystem.onHealthChanged += ChangeSprint;
    }

    private void OnDisable()
    {
        healthSystem.onHealthChanged -= ChangeSprint;
    }

    void ChangeSprint(float amount)
    {
        Debug.Log("Changing health by " + amount);
        slider.maxValue += amount;
        slider.value += amount;
    }


}
