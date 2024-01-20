using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireWall : MonoBehaviour
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
    private GameObject fireWallFake;
    [SerializeField]
    private GameObject fireWall;
    [SerializeField]
    private bool playerInRange;

    public int wallBreak;

    [SerializeField]
    private FireExtinguisher fireExtinguisher;

    public AudioSource audioSource;

    public AudioClip EarthquakeBlockDebris, SchoolAlarm, Debris, ItemPickUp, Button, Dialog;

    private void Awake()
    {
        visualCue.SetActive(false);
        wallBreak = 0;
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

    public void ButtonFire()
    {
        if (playerInRange && fireExtinguisher.extinguisherObtained)
        {
            if (wallBreak != 2)
            {
                wallBreak = 1;
            }

            dialogTextName.text = "Player:";
            dialogText.text = "Used the Fire Extinguisher to set the fire off.";
            fireWall.SetActive(false);
            fireWallFake.SetActive(true);
            Debug.Log("player range destroy");
            StartCoroutine(WallShake());

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                Debug.Log("dialog false 1st");
            }

            else
            {
                dialogBox.SetActive(true);
                Debug.Log("dialog true 1sd");
                audioSource.clip = Debris;
                audioSource.Play();
            }
        }

        else if (playerInRange)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "I need to set the fire off!";
            Debug.Log("player range");

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                Debug.Log("dialog false 2nd");
            }

            else
            {
                dialogBox.SetActive(true);
                Debug.Log("dialog true 2nd");
                audioSource.clip = Dialog;
                audioSource.Play();
            }
        }
    }

    private IEnumerator WallShake()
    {
        yield return new WaitForSeconds(2f);
        wallBreak = 2;
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
