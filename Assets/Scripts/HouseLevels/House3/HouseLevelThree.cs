using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HouseLevelThree : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;
    public GameObject fadeOut;
    public int closeDialog;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip EarthquakeBlockDebris, SchoolAlarm, Debris, Button, Dialog, Music;

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

    private void Awake()
    {
        dialogTextName.text = "Player:";
        dialogText.text = "Help should be somwhere here! I must head south direction.";
        closeDialog = 0;
        checkQuestion = false;
        playerLife = 3;
        fadeOut.SetActive(false);
    }

    private void Update()
    {
        ShowLife();
    }

    void Start()
    {
        audioSource2.clip = Music;
        audioSource2.Play();
        StartCoroutine(HouseStart());
    }

    public void ButtonFirstDialog()
    {
        if (closeDialog == 0)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                closeDialog = 1;

                if (!checkQuestion)
                {
                    checkQuestion = true;
                    panelShowQuestion.SetActive(true);
                }
            }

            else
            {
                dialogBox.SetActive(true);
                audioSource.clip = Dialog;
                audioSource.Play();
            }
        }
    }

    public IEnumerator HouseStart()
    {
        audioSource.clip = Dialog;
        audioSource.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        fadeOut.SetActive(false);
        dialogBox.SetActive(true);
    }

    public void CorrectAnswer()
    {
        buttonImage[1].GetComponent<Image>().color = Color.green;
        Debug.Log("Green");
        StartCoroutine(WaitAnswerCorrect());
        Debug.Log("Black");
    }

    public void ShowLife()
    {
        if (playerLife == 3)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (playerLife == 2)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (playerLife == 1)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(false);
            heartThree.SetActive(true);
        }
    }

    public void WrongAnswer()
    {
        playerLife -= 1;
        buttonImage[0].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerTwo()
    {
        playerLife -= 1;
        buttonImage[2].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerThree()
    {
        playerLife -= 1;
        buttonImage[3].GetComponent<Image>().color = Color.red;
        Debug.Log("Red");
        StartCoroutine(WaitAnswer());
        Debug.Log("Black");

        if (playerLife == 0)
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
