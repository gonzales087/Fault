using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTwo : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject fadeIn;
    [SerializeField]
    private bool playerInRange;

    public bool playSound;

    public AudioSource audioSource;

    public AudioClip Button, Dialog, LevelFinish;

    private void Awake()
    {
        playSound = true;
    }

    void Update()
    {
        if (playerInRange)
        {
            StartCoroutine(LevelDone());
        }
    }

    public void ButtonLevelComplete()
    {
        if (playerInRange)
        {
            StartCoroutine(LevelDone());
        }
    }

    public IEnumerator LevelDone()
    {
        fadeIn.SetActive(true);

        if (playSound)
        {
            audioSource.clip = LevelFinish;
            audioSource.Play();
            playSound = false;
        }

        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
