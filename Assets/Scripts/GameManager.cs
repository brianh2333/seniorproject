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

    public GameObject player;

    public GameObject crossfade;

    private void Update()
    {
        if (pauseScreen != null) {
            if (Input.GetKey(KeyCode.Escape) && !pauseScreen.activeSelf)
            {

                PauseGame();
            }
        }
    }

    void Awake()
    {
        _instance = this;
        crossfade.GetComponent<Animator>().SetTrigger("FadeOut");
        player = GameObject.FindWithTag("Player");
        Time.timeScale = 1f;
    }

    public void Reload()
    {
        StartCoroutine(ReloadIEnumerator());
    }

    public void ReturnToMenu()
    {
        StartCoroutine(MenuIEnumerator());
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
    }

    public void Play() {
        SceneManager.LoadScene("Level1");
    }

    public void Exit() {
        Application.Quit();
    }

    public IEnumerator ReloadIEnumerator()
    {
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level1");
    }

    public IEnumerator MenuIEnumerator()
    {
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}
