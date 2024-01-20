using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockPush : MonoBehaviour
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
    private bool playerInRange;

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

    public void ButtonRockPushable()
    {
        if (playerInRange)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "This boulder can be pushed to open the path!";

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
