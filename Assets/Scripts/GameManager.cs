using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance
    {
        get { 
                if (_instance == null)
                {
                    Debug.LogError("GameManager is NULL");
                }
                return _instance;
                
            }
    }
    void Awake()
    {
        _instance = this;
    }

    public void Reload()
    {
        SceneManager.LoadScene("Level1");
    }
}
