using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopEarthquake : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;

    private bool playerInRange;
    public int earthquakeStop;

    public StartEarthquake startEarthquake;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public AudioClip MainEarthquake, EarthquakeBlockDebris, SchoolAlarm, Debris, ItemPickUp, Button, Dialog;

    private void Awake()
    {
        earthquakeStop = 0;
    }

    void Update()
    {
        if (earthquakeStop == 1)
        {
            audioSource3.Stop();
            dialogTextName.text = "Player:";
            dialogText.text = "The earthquake stopped!";

            dialogBox.SetActive(true);
            earthquakeStop = 2;
        }

        if (earthquakeStop == 3)
        {
            startEarthquake.earthquakeStarted = 4;
        }
    }

    public void ButtonStop()
    {
        if (earthquakeStop == 2)
        {
            if (playerInRange)
            {

                dialogTextName.text = "Player:";
                dialogText.text = "The earthquake stopped!";
                earthquakeStop = 3;

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

            if (earthquakeStop == 0)
            {
                earthquakeStop = 1;
            }

            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("exit");
        }
    }
}
