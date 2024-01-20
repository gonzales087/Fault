using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireExtinguisher : MonoBehaviour
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
    private GameObject extinguisherObject;
    private bool playerInRange;

    public bool extinguisherObtained;

    public AudioSource audioSource;

    public AudioClip ItemPickUp;

    [SerializeField]
    private GameObject showDirection;

    public TriggerQuestionSecond triggerQuestionSecond;

    private void Awake()
    {
        visualCue.SetActive(false);
        extinguisherObtained = false;
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

        if (triggerQuestionSecond.checkQuestion) {

            if (extinguisherObtained)
            {
                showDirection.SetActive(false);
            }

            else {
                if (!triggerQuestionSecond.panelShowQuestion.activeInHierarchy)
                {
                    showDirection.SetActive(true);
                }
            }

        }
    }

    public void ButtonActionTable()
    {
        if (playerInRange)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "You picked up the fire extinguisher. It can be use to set off the fire.";
            extinguisherObtained = true;

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                extinguisherObject.SetActive(false);
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
