using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntranceFourBlock : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;
    [SerializeField]
    private GameObject storyAnimation1;

    private bool playerInRange;
    public int earthquakeStarted;

    [SerializeField]
    private GameObject fakeLocker;

    public AudioSource audioSource;

    public AudioClip MainEarthquake, EarthquakeBlockDebris, SchoolAlarm, Debris, Button, Dialog;

    private void Awake()
    {
        earthquakeStarted = 0;
        storyAnimation1.SetActive(false);
        fakeLocker.SetActive(true);
    }

    void Update()
    {
        if (earthquakeStarted == 1)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "The locker is blocking the path.";

            dialogBox.SetActive(true);
            StartCoroutine(OneSecond());
            fakeLocker.SetActive(false);
            storyAnimation1.SetActive(true);
        }
    }

    public void ButtonLocker()
    {
        if (earthquakeStarted == 2)
        {
            if (playerInRange)
            {

                dialogTextName.text = "Player:";
                dialogText.text = "The locker is blocking the path.";
                earthquakeStarted = 3;

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

    private IEnumerator OneSecond()
    {
        audioSource.clip = EarthquakeBlockDebris;
        audioSource.Play();
        yield return new WaitForSeconds(0.2f);
        earthquakeStarted = 2;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;

            if (earthquakeStarted == 0)
            {
                earthquakeStarted = 1;
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
