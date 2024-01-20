using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSam : MonoBehaviour
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

    public void ButtonNPCSam()
    {
        if (playerInRange)
        {
            dialogTextName.text = "Sam:";
            dialogText.text = "Hey, the path down to 1st floor is blocked by big boulder. It seems that the boulder can be pushed down with enough man power. There are other people in this floor. You should find them and ask for help so we can push it together.";
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
