using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoMedKit : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;
    [SerializeField]
    private bool playerInRange;

    public int noMedkit;

    public NPCBob npcBob;

    public AudioSource audioSource;

    public AudioClip Dialog;

    private void Awake()
    {
        noMedkit = 0;
    }

    void Update()
    {
        if (playerInRange)
        {
            if (noMedkit == 0 && npcBob.bobStory == 1)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "There's no med kit here, I should go back to my brother now.";

                audioSource.clip = Dialog;
                audioSource.Play();

                dialogBox.SetActive(true);
                noMedkit = 1;
            }
        }
    }

    public void ButtonNoMedKit()
    {
        if (noMedkit == 1)
        {
            Debug.Log("1xd");
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "There's no med kit here, I should go back to my brother now.";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    noMedkit = 2;
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
