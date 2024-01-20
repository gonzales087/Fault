using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerQuestion : MonoBehaviour
{
    public bool checkQuestion;
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

    public int questionStart;

    [SerializeField]
    private Color buttonColor;
    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    private void Awake()
    {
        questionStart = 0;
        checkQuestion = false;
        playerLife = 3;
    }

    void Update()
    {
        if (questionStart == 1)
        {
            StartCoroutine(OneSecond());

            if (!checkQuestion)
            {
                checkQuestion = true;
                panelShowQuestion.SetActive(true);
            }
        }

        ShowLife();
    }

    private IEnumerator OneSecond()
    {
        yield return new WaitForSeconds(0.2f);
        questionStart = 2;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            questionStart = 1;
            Debug.Log("enter");
        }
    }

    public void CorrectAnswerB()
    {
        buttonImage[1].GetComponent<Image>().color = Color.green;
        Debug.Log("Green");
        StartCoroutine(WaitAnswerCorrect());
        Debug.Log("Black");
    }

    public void CorrectAnswerC()
    {
        buttonImage[2].GetComponent<Image>().color = Color.green;
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
        buttonImage[1].GetComponent<Image>().color = Color.red;
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
        buttonImage[2].GetComponent<Image>().color = Color.red;
        Debug.Log("Red");
        StartCoroutine(WaitAnswer());
        Debug.Log("Black");

        if (playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerFour()
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
