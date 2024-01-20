using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCAxe : MonoBehaviour
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

    private void Awake()
    {
        visualCue.SetActive(false);
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

    public void ButtonNPCMark()
    {
        if (playerInRange)
        {
            dialogTextName.text = "Mark:";
            dialogText.text = "You should examine that wall over there.";
            Debug.Log("player range");

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                Debug.Log("dialog false");
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
