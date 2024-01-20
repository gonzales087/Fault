using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HouseTableCover : MonoBehaviour
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

    public TriggerHouseEarthquake triggerHouseEarthquake;

    [SerializeField]
    private GameObject storyAnimationDuckCover;
    [SerializeField]
    private GameObject storyAnimationDuckCover2;
    [SerializeField]
    private GameObject storyAnimationDuckCover3;
    [SerializeField]
    private GameObject storyAnimationDuckCover4;
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

    [SerializeField]
    private bool checkQuestion;
    public int playerLife;
    [SerializeField]
    private GameObject panelShowQuestion;
    [SerializeField]
    private GameObject heartOne;
    [SerializeField]
    private GameObject heartTwo;
    [SerializeField]
    private GameObject heartThree;
    [SerializeField]
    private GameObject panelGameOver;

    [SerializeField]
    private Color buttonColor;
    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    public void StoryHouseOneButton()
    {
        audioSource.clip = Dialog;
        audioSource.Play();
        storyAnimationDuckCover2.SetActive(false);
        storyAnimationDuckCover3.SetActive(true);
    }

    public void StoryHouseTwoButton()
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
        Debug.Log(triggerHouseEarthquake.earthquakeStarted);

        if (triggerHouseEarthquake.earthquakeStarted == 3)
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

        ShowLife();
    }

    public void ButtonActionTable()
    {
        if (triggerHouseEarthquake.earthquakeStarted == 3)
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

        if (triggerHouseEarthquake.earthquakeStarted == 4)
        {
            audioSource.clip = Dialog;
            audioSource.Play();
            dialogBox.SetActive(false);
            triggerHouseEarthquake.earthquakeStarted = 5;
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
        triggerHouseEarthquake.earthquakeStarted = 4;
        propsBefore.SetActive(false);
        propsAfter.SetActive(true);
        visualCue.SetActive(false);
        fallingDebris.SetActive(false);
        aftermathDebris.SetActive(true);
        yield return new WaitForSeconds(2f);
        storyAnimationDuckCover4.SetActive(false);
        dialogTextName.text = "Player:";
        dialogText.text = "I need to look for my family.";
        dialogBox.SetActive(true);

        if (!checkQuestion)
        {
            checkQuestion = true;
            panelShowQuestion.SetActive(true);
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

    public void CorrectAnswer()
    {
        buttonImage[2].GetComponent<Image>().color = Color.green;
        Debug.Log("Green");
        StartCoroutine(WaitAnswerCorrect());
        Debug.Log("Black");
    }

    public void ShowLife()
    {
        if (triggerHouseEarthquake.playerLife == 3)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (triggerHouseEarthquake.playerLife == 2)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (triggerHouseEarthquake.playerLife == 1)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(false);
            heartThree.SetActive(true);
        }
    }

    public void WrongAnswer()
    {
        triggerHouseEarthquake.playerLife -= 1;
        buttonImage[0].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (triggerHouseEarthquake.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerTwo()
    {
        triggerHouseEarthquake.playerLife -= 1;
        buttonImage[1].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (triggerHouseEarthquake.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerThree()
    {
        triggerHouseEarthquake.playerLife -= 1;
        buttonImage[3].GetComponent<Image>().color = Color.red;
        Debug.Log("Red");
        StartCoroutine(WaitAnswer());
        Debug.Log("Black");

        if (triggerHouseEarthquake.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public IEnumerator WaitAnswer()
    {
        buttonQuestion[0].interactable = false;
        buttonQuestion[1].interactable = false;
        buttonQuestion[2].interactable = false;
        buttonQuestion[3].interactable = false;
        yield return new WaitForSeconds(1f);
        buttonImage[0].GetComponent<Image>().color = Color.black;
        buttonImage[1].GetComponent<Image>().color = Color.black;
        buttonImage[2].GetComponent<Image>().color = Color.black;
        buttonImage[3].GetComponent<Image>().color = Color.black;
        buttonQuestion[0].interactable = true;
        buttonQuestion[1].interactable = true;
        buttonQuestion[2].interactable = true;
        buttonQuestion[3].interactable = true;
    }

    public IEnumerator WaitAnswerCorrect()
    {
        yield return new WaitForSeconds(1f);
        buttonImage[0].GetComponent<Image>().color = Color.black;
        buttonImage[1].GetComponent<Image>().color = Color.black;
        buttonImage[2].GetComponent<Image>().color = Color.black;
        buttonImage[3].GetComponent<Image>().color = Color.black;
        buttonQuestion[0].interactable = true;
        buttonQuestion[1].interactable = true;
        buttonQuestion[2].interactable = true;
        buttonQuestion[3].interactable = true;
        panelShowQuestion.SetActive(false);
    }
}
