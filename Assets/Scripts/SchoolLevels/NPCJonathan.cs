using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCJonathan : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;
    [SerializeField]
    private GameObject visualCue;
    [SerializeField]
    private bool playerInRange;

    public int jonathanStory;

    [SerializeField]
    private GameObject realJonathan;
    [SerializeField]
    private GameObject fakeJonathan;
    [SerializeField]
    private GameObject fadeIn;
    [SerializeField]
    private GameObject fadeOut;

    public bool jonathanHelp;

    public AudioSource audioSource;

    public AudioClip Dialog;

    private void Awake()
    {
        visualCue.SetActive(false);
        jonathanStory = 0;
    }

    void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
        }

        else
        {
            visualCue.SetActive(false);
        }
    }

    public void ButtonNPCVince()
    {
        if (jonathanStory == 0)
        {
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "Hey! Please help us push the boulder! Let's get out of this building!";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    jonathanStory = 1;
                }

                else
                {
                    dialogBox.SetActive(true);
                    Debug.Log("dialog true");
                    audioSource.clip = Dialog;
                    audioSource.Play();
                }
            }
        }

        else if (jonathanStory == 1)
        {
            if (playerInRange)
            {
                dialogTextName.text = "Jonathan:";
                dialogText.text = "Let's go!";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    StartCoroutine(BernardAnimation());
                }

                else
                {
                    dialogBox.SetActive(true);
                    Debug.Log("dialog true");
                    audioSource.clip = Dialog;
                    audioSource.Play();
                }
            }
        }
    }

    private IEnumerator BernardAnimation()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1f);
        fakeJonathan.SetActive(true);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
        realJonathan.SetActive(false);
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
