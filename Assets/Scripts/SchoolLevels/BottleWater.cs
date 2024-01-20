using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottleWater : MonoBehaviour
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
    [SerializeField]
    private GameObject bottleWaterProp;

    public bool bottleWaterObtained;

    public AudioSource audioSource;

    public AudioClip ItemPickUp;

    private void Awake()
    {
        visualCue.SetActive(false);
        bottleWaterProp.SetActive(true);
        bottleWaterObtained = false;
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

    public void ButtonBottleWater()
    {

        if (playerInRange)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "You obtained bottle of water.";
            bottleWaterObtained = true;
            Debug.Log("player range");

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                bottleWaterProp.SetActive(false);
                Debug.Log("dialog false");
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
