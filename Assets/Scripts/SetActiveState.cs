using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to set an object inactive.
//Necessary so scripts can grab this object as a reference.
public class SetActiveState : MonoBehaviour
{
    public bool state = false;
    void Awake()
    {
        StartCoroutine(SetState(false));
    }

    IEnumerator SetState(bool state)
    {
        yield return new WaitForSeconds(.2f);
        gameObject.SetActive(state);
    }
}
