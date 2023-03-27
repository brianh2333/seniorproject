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

    public GameObject pauseScreen;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !pauseScreen.activeSelf)
        {

            PauseGame();
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

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
}
