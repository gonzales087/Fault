using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
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
    private GameObject axeObject;
    private bool playerInRange;

    public bool keyObtained;

    public AudioSource audioSource;

    public AudioClip Dialog, ItemPickUp;

    private void Awake()
    {
        visualCue.SetActive(false);
        keyObtained = false;
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

    public void ButtonKey()
    {
        if (playerInRange)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "You picked up the key. This can be used to open brother's room!";
            keyObtained = true;

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                axeObject.SetActive(false);
            }

            else
            {
                dialogBox.SetActive(true);
                audioSource.clip = ItemPickUp;
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
