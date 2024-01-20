using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuckInstruction : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;

    public EarthquakeTrigger earthquakeTrigger;
    [SerializeField]
    private GameObject hideTrigger;

    private bool playerInRange;
    public int dialogOpened;

    private void Awake()
    {
        dialogOpened = 0;
    }

    void Update()
    {
        if (dialogOpened == 1)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "I should duck, cover, and hold below the desk!";

            dialogBox.SetActive(true);
            dialogOpened = 2;
        }

        if (earthquakeTrigger.earthquakeStarted == 5)
        {
            hideTrigger.SetActive(false);
        }
    }

    public void ButtonDuckCoverHold()
    {
        if (dialogOpened == 2)
        {
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "I should duck, cover, and hold below the desk!";
                dialogOpened = 3;

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }

                else
                {
                    dialogBox.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("enter");

            if (dialogOpened == 0)
            {
                dialogOpened = 1;
            }

            else if (dialogOpened == 3)
            {
                dialogOpened = 4;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("exit");
            dialogOpened = 0;

            if (dialogOpened == 4)
            {
                dialogOpened = 0;
            }
        }
    }
}
