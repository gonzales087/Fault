using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCClearLevel : MonoBehaviour
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

    public AudioSource audioSource;

    public AudioClip Dialog;

    private int dilogCounter;
    [SerializeField]
    private GameObject levelClear;

    private void Awake()
    {
        visualCue.SetActive(false);
        dilogCounter = 0;
        levelClear.SetActive(false);
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

    public void ButtonNPCRescuer()
    {
        if (playerInRange)
        {
            if (dilogCounter == 0) {
                dialogTextName.text = "Player:";
                dialogText.text = "Help me! My brother needs help in our house!";

                dialogBox.SetActive(true);
                audioSource.clip = Dialog;
                audioSource.Play();
            }

            else if (dilogCounter == 1) {
                dialogTextName.text = "Rescuer:";
                dialogText.text = "Let's go now!";

                dialogBox.SetActive(true);
                audioSource.clip = Dialog;
                audioSource.Play();
            }

            else if (dilogCounter == 2) {
                levelClear.SetActive(true);
            }

            dilogCounter += 1;
        }
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
