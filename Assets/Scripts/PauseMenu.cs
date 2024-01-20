using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    public AudioSource audioSource;

    public AudioClip Button, Dialog;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        audioSource.clip = Button;
        audioSource.Play();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        audioSource.clip = Button;
        audioSource.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        audioSource.clip = Button;
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
