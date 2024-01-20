using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WallBreak : MonoBehaviour
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
    private GameObject wallFake;
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private bool playerInRange;

    public int wallBreak;

    [SerializeField]
    private Axe axe;

    public AudioSource audioSource;

    public AudioClip EarthquakeBlockDebris, SchoolAlarm, Debris, ItemPickUp, Button, Dialog;

    [SerializeField]
    private bool checkQuestion;
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

    public EarthquakeTrigger earthquakeTrigger;

    [SerializeField]
    private GameObject showDirection;

    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    private void Awake()
    {
        visualCue.SetActive(false);
        wallBreak = 0;
    }

    void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
        }

        else
        {
            visualCue.SetActive(false);
        }

        ShowLife();

        if (axe.axeObtained)
        {
            showDirection.SetActive(false);
        }
    }

    public void ButtonWall()
    {
        if (playerInRange && axe.axeObtained)
        {
            if (wallBreak != 2)
            {
                wallBreak = 1;
            }

            dialogTextName.text = "Player:";
            dialogText.text = "Used the axe to destroy the wall.";
            wallFake.SetActive(false);
            wall.SetActive(true);
            Debug.Log("player range destroy");
            StartCoroutine(WallShake());

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);

                if (!checkQuestion)
                {
                    checkQuestion = true;
                    panelShowQuestion.SetActive(true);

                    if (!axe.axeObtained)
                    {
                        showDirection.SetActive(true);
                    }
                }
            }

            else
            {
                dialogBox.SetActive(true);
                Debug.Log("dialog true 1sd");
                audioSource.clip = Debris;
                audioSource.Play();
            }
        }

        else if (playerInRange)
        {
            dialogTextName.text = "Player:";
            dialogText.text = "This wall seems to be damaged.";
            Debug.Log("player range");

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                Debug.Log("dialog false 2nd");

                if (!checkQuestion)
                {
                    checkQuestion = true;
                    panelShowQuestion.SetActive(true);

                    if (!axe.axeObtained)
                    {
                        showDirection.SetActive(true);
                    }
                }
            }

            else
            {
                dialogBox.SetActive(true);
                Debug.Log("dialog true 2nd");
                audioSource.clip = Dialog;
                audioSource.Play();
            }
        }
    }

    private IEnumerator WallShake()
    {
        yield return new WaitForSeconds(0.2f);
        wallBreak = 2;
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
        if (earthquakeTrigger.playerLife == 3)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (earthquakeTrigger.playerLife == 2)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }

        else if (earthquakeTrigger.playerLife == 1)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(false);
            heartThree.SetActive(true);
        }
    }

    public void WrongAnswer()
    {
        earthquakeTrigger.playerLife -= 1;
        buttonImage[0].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (earthquakeTrigger.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }
    public void WrongAnswerTwo()
    {
        earthquakeTrigger.playerLife -= 1;
        buttonImage[1].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

        if (earthquakeTrigger.playerLife == 0)
        {
            panelShowQuestion.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void WrongAnswerThree()
    {
        earthquakeTrigger.playerLife -= 1;
        buttonImage[3].GetComponent<Image>().color = Color.red;
        Debug.Log("Red");
        StartCoroutine(WaitAnswer());
        Debug.Log("Black");

        if (earthquakeTrigger.playerLife == 0)
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
