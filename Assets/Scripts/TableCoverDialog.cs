using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class TableCoverDialog : MonoBehaviour
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

    public EarthquakeTrigger earthquakeTrigger;

    [SerializeField]
    private GameObject storyAnimationDuckCover;
    [SerializeField]
    private GameObject storyAnimationDuckCover2;
    [SerializeField]
    private GameObject storyAnimationDuckCover3;
    [SerializeField]
    private GameObject storyAnimationDuckCover4;
    [SerializeField]
    private GameObject blockEntrance;
    [SerializeField]
    private GameObject fallingDebris;
    [SerializeField]
    private GameObject aftermathDebris;
    [SerializeField]
    private GameObject propsBefore;
    [SerializeField]
    private GameObject propsAfter;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public AudioClip Dialog, ItemPick;

    public void storyOneButton()
    {
        audioSource.clip = Dialog;
        audioSource.Play();
        storyAnimationDuckCover2.SetActive(false);
        storyAnimationDuckCover3.SetActive(true);
    }

    public void storyTwoButton()
    {
        audioSource.clip = Dialog;
        audioSource.Play();
        storyAnimationDuckCover3.SetActive(false);
        storyAnimationDuckCover4.SetActive(true);
        StartCoroutine(TwoSecond());
    }

    private void Awake()
    {
        visualCue.SetActive(false);
        storyAnimationDuckCover.SetActive(false);
    }

    void Update()
    {
        Debug.Log(earthquakeTrigger.earthquakeStarted);

        if (earthquakeTrigger.earthquakeStarted == 3)
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

        else
        {
            visualCue.SetActive(false);
        }
    }

    public void ButtonActionTable()
    {
        if (earthquakeTrigger.earthquakeStarted == 3)
        {
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "I should duck, cover, and hold below the desk!";

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    StartCoroutine(DuckCoverAnimation());
                }

                else
                {
                    dialogBox.SetActive(true);
                    audioSource.clip = Dialog;
                    audioSource.Play();
                }
            }
        }

        if (earthquakeTrigger.earthquakeStarted == 4)
        {
            audioSource.clip = Dialog;
            audioSource.Play();
            dialogBox.SetActive(false);
            earthquakeTrigger.earthquakeStarted = 5;
        }
    }

    private IEnumerator DuckCoverAnimation()
    {
        storyAnimationDuckCover.SetActive(true);
        yield return new WaitForSeconds(2f);
        storyAnimationDuckCover.SetActive(false);
        storyAnimationDuckCover2.SetActive(true);
    }

    private IEnumerator TwoSecond()
    {
        audioSource2.Stop();
        audioSource3.Stop();
        earthquakeTrigger.earthquakeStarted = 4;
        propsBefore.SetActive(false);
        propsAfter.SetActive(true);
        visualCue.SetActive(false);
        blockEntrance.SetActive(false);
        fallingDebris.SetActive(false);
        aftermathDebris.SetActive(true);
        yield return new WaitForSeconds(2f);
        storyAnimationDuckCover4.SetActive(false);
        dialogTextName.text = "Player:";
        dialogText.text = "I should find a way to exit the building.";
        dialogBox.SetActive(true);
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
