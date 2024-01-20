using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyMainDoor : MonoBehaviour
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
    private GameObject hideKeyMainDoor;
    private bool playerInRange;

    public bool keyMainDoorObtained;

    public NPCBob npcBob;

    public AudioSource audioSource;

    public AudioClip ItemPickUp;

    private void Awake()
    {
        visualCue.SetActive(false);
        keyMainDoorObtained = false;
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

    public void ButtonMainDoorKey()
    {
        if (playerInRange && npcBob.bobStory == 3)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "You picked up the main door key.";
            keyMainDoorObtained = true;

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                hideKeyMainDoor.SetActive(false);
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
