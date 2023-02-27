using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesRemaining : MonoBehaviour
{
    private int enemies = -1;
    public Image prefab;
    void Awake()
    {
        Transform enemyTransform = GameObject.FindGameObjectWithTag("Enemies").transform;
        for (int i = 0; i < enemyTransform.childCount; i++)
        {
            enemies++;
            Instantiate(prefab, transform);
        }
    }

    public void Remove()
    {
        transform.GetChild(enemies--).gameObject.SetActive(false);
    }

}
