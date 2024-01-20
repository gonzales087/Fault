using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCBernard : MonoBehaviour
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

    private int bernardStory;

    public BottleWater bottleWater;

    [SerializeField]
    private GameObject realBernard;
    [SerializeField]
    private GameObject fakeBernard;
    [SerializeField]
    private GameObject fadeIn;
    [SerializeField]
    private GameObject fadeOut;

    public bool bernardHelp;

    public AudioSource audioSource;

    public AudioClip Dialog;

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

    [SerializeField]
    private Color buttonColor;
    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    private void Awake()
    {
        visualCue.SetActive(false);
        bernardStory = 0;
        checkQuestion = false;
        playerLife = 3;
    }

    void Update()
    {
        if (bottleWater.bottleWaterObtained == true)
        {
            if (bernardStory == 0)
            {
                bernardStory = 1;
            }
        }

        if (playerInRange)
        {
            visualCue.SetActive(true);
        }

        else
        {
            visualCue.SetActive(false);
        }

        ShowLife();
    }

    public void ButtonNPCBernard()
    {
        if (bernardStory == 0)
        {
            Debug.Log("1xd");
            if (playerInRange)
            {
                dialogTextName.text = "Bernard:";
                dialogText.text = ".... I’m dehydrated.";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");

                    if (!checkQuestion)
                    {
                        checkQuestion = true;
                        panelShowQuestion.SetActive(true);
                    }
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

        else if (bernardStory == 1)
        {
            Debug.Log("2xd");
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "You gave the water to Bernard.";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    bernardStory = 2;

                    if (!checkQuestion)
                    {
                        checkQuestion = true;
                        panelShowQuestion.SetActive(true);
                    }
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

        else if (bernardStory == 2)
        {
            Debug.Log("3xd");
            if (playerInRange)
            {
                dialogTextName.text = "Bernard:";
                dialogText.text = "Thank you so much, I'm feeling refreshed now! Let's get out of this building!";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    StartCoroutine(BernardAnimation());
                }

                else
                {
                    dialogBox.SetActive(true);
                    Debug.Log("dialog true");
                }
            }
        }
    }

    private IEnumerator BernardAnimation()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1f);
        fakeBernard.SetActive(true);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
        realBernard.SetActive(false);
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
