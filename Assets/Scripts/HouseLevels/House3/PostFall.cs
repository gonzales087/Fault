using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostFall : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;
    [SerializeField]
    private GameObject postAnimation;
    [SerializeField]
    private GameObject postFake;

    private bool playerInRange;
    public int earthquakeStarted;

    public AudioSource audioSource;

    public AudioClip MainEarthquake, EarthquakeBlockDebris, SchoolAlarm, Debris, Button, Dialog;

    private void Awake()
    {
        earthquakeStarted = 0;
        postAnimation.SetActive(false);
        postFake.SetActive(true);
    }

    void Update()
    {
        if (earthquakeStarted == 1)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "The light post fell down!";

            dialogBox.SetActive(true);
            postFake.SetActive(false);
            StartCoroutine(OneSecond());
            postAnimation.SetActive(true);
        }
    }

    public void ButtonActionTreeOne()
    {
        if (earthquakeStarted == 2)
        {
            if (playerInRange)
            {

                dialogTextName.text = "Player:";
                dialogText.text = "The light post fell down!";
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
