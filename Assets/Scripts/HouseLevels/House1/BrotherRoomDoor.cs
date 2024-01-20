using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrotherRoomDoor : MonoBehaviour
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

    public Key key;

    [SerializeField]
    private GameObject hideDoor;

    public AudioSource audioSource;

    public AudioClip Dialog, ItemPickUp;

    [SerializeField]
    private GameObject showDirection;

    private void Awake()
    {
        visualCue.SetActive(false);
        hideDoor.SetActive(true);
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

        if (key.keyObtained)
        {
            showDirection.SetActive(false);
        }
    }

    public void ButtonBrotherDoor()
    {
        if (key.keyObtained)
        {
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "The door opened!";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    hideDoor.SetActive(false);

                    if (!key.keyObtained)
                    {
                        showDirection.SetActive(true);
                    }
                }

                else
                {
                    dialogBox.SetActive(true);
                    Debug.Log("dialog true");
                    audioSource.clip = ItemPickUp;
                    audioSource.Play();
                }
            }
        }

        else
        {
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "The door is locked, I should find the key.";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");

                    if (!key.keyObtained)
                    {
                        showDirection.SetActive(true);
                    }
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
