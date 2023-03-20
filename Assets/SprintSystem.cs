using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintSystem : MonoBehaviour
{

    public delegate void OnHealthChanged(float health, float maxHealth);
    public event OnHealthChanged onHealthChanged = delegate { };

    [SerializeField] private float maxSprintTime = 3f;
    [SerializeField] private float currSprintTime;
    
    //How long until sprint can regen.
    [SerializeField] private float maxWaitTime = 2f;
    [SerializeField] private float currWaitTime;

    public bool inUse = false;


    private void Start()
    {
        currSprintTime = maxSprintTime;
        currWaitTime = maxWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (inUse)
        {
            if (currSprintTime >= maxSprintTime)
            {
                currSprintTime -= Time.deltaTime;
            }
        }
        else
        {
            if (currSprintTime <= maxSprintTime)
            {
                if (currWaitTime < maxWaitTime)
                {
                    currWaitTime += Time.deltaTime;
                } 
                else
                {
                    currSprintTime += Time.deltaTime;
                }
            }

        }
    }

    public void setInUse(bool use)
    {
        inUse = use;
    }
}
