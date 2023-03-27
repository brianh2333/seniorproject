using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public delegate void OnSprintFinished();
    public event OnSprintFinished onSprintFinished = delegate { };

    public Slider slider;

    //public Image fill;

    bool canRegen = false;

    [SerializeField] private float maxSprintTime = 3f;
    
    //How long until sprint can regen.
    [SerializeField] private float maxWaitTime = 2f;
    [SerializeField] private float currWaitTime;

    [SerializeField] private bool inUse = false;


    private void Start()
    {
        slider.maxValue = maxSprintTime;
        slider.value = maxSprintTime;
        currWaitTime = maxWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (inUse && currWaitTime >= maxWaitTime)
        {
            if (slider.value > 0f)
            {
                slider.value -= Time.deltaTime;
                slider.value = Mathf.Clamp(slider.value, 0f, maxSprintTime);
            }
            else {
                inUse = false;
                onSprintFinished();
                currWaitTime = 0f;
            }
        }
        else
        {
            if (slider.value < slider.maxValue)
            {
                if (currWaitTime < maxWaitTime)
                {
                    currWaitTime += Time.deltaTime;
                } 
                else
                {
                    slider.value += Time.deltaTime;
                    slider.value = Mathf.Clamp(slider.value, 0f, maxSprintTime);
                }
            }

        }
    }

    public void setInUse(bool use)
    {
        inUse = use;
    }

    public bool getInUse()
    {
        return inUse;
    }


    // public SprintSystem sprintSystem;

    // public Slider slider;

    // public Image fill;

    // bool canRegen = false;


    // private void Awake()
    // {
    //     sprintSystem.onSprintChanged += ChangeSprint;
    // }

    // private void OnDisable()
    // {
    //     sprintSystem.onSprintChanged -= ChangeSprint;
    // }

    // void Update() {
        
    // }

    // void SetSprint(float amount)
    // {
    //     slider.maxValue = amount
    //     slider.value = amount;
    // }

    // void UseSprint()
    // {
    //     Debug.Log("Changing health by " + amount);
    //     slider.maxValue -= Time.deltaTime;
    //     slider.value += amount;
    // }

    // void RegenSprint()
    // {
    //     while (slider.value < )
    //     slider.value += Time.deltaTime;
    // }


}
