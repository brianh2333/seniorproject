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

    public GameObject instructionsPart1;

    public GameObject instructionsPart2;

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
        StartCoroutine(PlayIEnumerator());
    }

    public void Exit() {
        Application.Quit();
    }

    public void InstructionsPart1() {
        StartCoroutine(InstructionsPart1IEnumerator());
    }

    public void InstructionsPart2() {
        StartCoroutine(InstructionsPart2IEnumerator());
    }

    //From the instructions
    public void ReturnToMenu() {
        StartCoroutine(ReturnToMenuIEnumerator());
    }

    public void Reload()
    {
        StartCoroutine(ReloadIEnumerator());
    }

    //From the game scene
    public void Menu()
    {
        StartCoroutine(MenuIEnumerator());
    }


    public IEnumerator PlayIEnumerator()
    {
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level1");
    }

    public IEnumerator InstructionsPart1IEnumerator()
    {
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        instructionsPart1.SetActive(true);
        crossfade.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public IEnumerator InstructionsPart2IEnumerator()
    {
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        instructionsPart1.SetActive(false);
        instructionsPart2.SetActive(true);
        crossfade.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public IEnumerator ReturnToMenuIEnumerator()
    {
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        instructionsPart2.SetActive(false);
        crossfade.GetComponent<Animator>().SetTrigger("FadeOut");
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
