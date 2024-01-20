using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerAfterShock : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;

    private bool playerInRange;
    public int earthquakeStarted;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public AudioClip MainEarthquake, EarthquakeBlockDebris, Debris, ItemPickUp, Button, Dialog;

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

    public EntranceOneBlock entranceOneBlock;

    [SerializeField]
    private Color buttonColor;
    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    private void Awake()
    {
        earthquakeStarted = 0;
    }

    void Update()
    {
        if (earthquakeStarted == 1)
        {
            audioSource3.clip = MainEarthquake;
            audioSource3.Play();
            dialogTextName.text = "Player:";
            dialogText.text = "Ahhh aftershock!";

            dialogBox.SetActive(true);
            earthquakeStarted = 2;
        }

        ShowLife();
    }

    public void ButtonActionEarthquake()
    {
        if (earthquakeStarted == 2)
        {
            if (playerInRange)
            {
                audioSource3.Stop();
                dialogTextName.text = "Player:";
                dialogText.text = "Ahhh aftershock!";
                earthquakeStarted = 3;

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);

                    if (!checkQuestion)
                    {
                        checkQuestion = true;
                        panelShowQuestion.SetActive(true);
                    }
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

    public void CorrectAnswer()
    {
        buttonImage[2].GetComponent<Image>().color = Color.green;
        Debug.Log("Green");
        StartCoroutine(WaitAnswerCorrect());
        Debug.Log("Black");
    }

    public void ShowLife()
    {
        if (entranceOneBlock.playerLife == 3)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (entranceOneBlock.playerLife == 2)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (entranceOneBlock.playerLife == 1)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(false);
            heartThree.SetActive(true);
        }
    }

    public void WrongAnswer()
    {
        entranceOneBlock.playerLife -= 1;
        buttonImage[0].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (entranceOneBlock.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerTwo()
    {
        entranceOneBlock.playerLife -= 1;
        buttonImage[1].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (entranceOneBlock.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerThree()
    {
        entranceOneBlock.playerLife -= 1;
        buttonImage[3].GetComponent<Image>().color = Color.red;
        Debug.Log("Red");
        StartCoroutine(WaitAnswer());
        Debug.Log("Black");

        if (entranceOneBlock.playerLife == 0)
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
