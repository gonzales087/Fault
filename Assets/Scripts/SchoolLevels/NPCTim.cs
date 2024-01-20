using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCTim : MonoBehaviour
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

    private int timStory;

    public MedKit medkit;

    [SerializeField]
    private GameObject realTim;
    [SerializeField]
    private GameObject fakeTim;
    [SerializeField]
    private GameObject realVince;
    [SerializeField]
    private GameObject fakeVince;

    [SerializeField]
    private GameObject fadeIn;
    [SerializeField]
    private GameObject fadeOut;

    public bool TimVinceHelp;

    public AudioSource audioSource;

    public AudioClip Dialog;

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

    public NPCBernard nPCBernard;

    [SerializeField]
    private Color buttonColor;
    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    private void Awake()
    {
        visualCue.SetActive(false);
        timStory = 0;
    }

    void Update()
    {
        if (medkit.MedKitObtained == true)
        {
            if (timStory == 0)
            {
                timStory = 1;
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

    public void ButtonNPCTim()
    {
        if (timStory == 0)
        {
            Debug.Log("1xd");
            if (playerInRange)
            {
                dialogTextName.text = "Tim:";
                dialogText.text = "I'm bleeding, find me something to stop the bleeding.";
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

        else if (timStory == 1)
        {
            Debug.Log("2xd");
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "You wrap the bandage on Tim's wounds.";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    timStory = 2;

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

        else if (timStory == 2)
        {
            Debug.Log("3xd");
            if (playerInRange)
            {
                dialogTextName.text = "Tim:";
                dialogText.text = "Thank you so much, the bleeding stopped! Vince and I will wait for the others on the stairs.";
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
                    audioSource.clip = Dialog;
                    audioSource.Play();
                }
            }
        }
    }

    private IEnumerator BernardAnimation()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1f);
        fakeTim.SetActive(true);
        fakeVince.SetActive(true);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
        realVince.SetActive(false);
        realTim.SetActive(false);
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
        buttonImage[0].GetComponent<Image>().color = Color.green;
        Debug.Log("Green");
        StartCoroutine(WaitAnswerCorrect());
        Debug.Log("Black");
    }

    public void ShowLife()
    {
        if (nPCBernard.playerLife == 3)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (nPCBernard.playerLife == 2)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (nPCBernard.playerLife == 1)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(false);
            heartThree.SetActive(true);
        }
    }

    public void WrongAnswer()
    {
        nPCBernard.playerLife -= 1;
        buttonImage[1].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (nPCBernard.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerTwo()
    {
        nPCBernard.playerLife -= 1;
        buttonImage[2].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (nPCBernard.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerThree()
    {
        nPCBernard.playerLife -= 1;
        buttonImage[3].GetComponent<Image>().color = Color.red;
        Debug.Log("Red");
        StartCoroutine(WaitAnswer());
        Debug.Log("Black");

        if (nPCBernard.playerLife == 0)
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
