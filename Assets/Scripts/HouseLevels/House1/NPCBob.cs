using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCBob : MonoBehaviour
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
    private bool checker;

    public int bobStory;

    public Key key;
    public NoMedKit noMedKit;
    [SerializeField]
    private GameObject keyMainDoor;

    public KeyMainDoor keyDoor;

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

    public TriggerHouseEarthquake triggerHouseEarthquake;

    [SerializeField]
    private Color buttonColor;
    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    private void Awake()
    {
        visualCue.SetActive(false);
        bobStory = 0;
        checker = false;
    }

    void Update()
    {
        if (key.keyObtained)
        {
            if (bobStory == 0)
            {
                bobStory = 1;
                Debug.Log("owie1");
            }
        }

        if (noMedKit.noMedkit == 2)
        {
            if (bobStory != 3 )
            {
                bobStory = 2;
            }
        }

        if (bobStory == 3 && checker)
        {
            Debug.Log("jose1");
            if (keyDoor.keyMainDoorObtained)
            {
                Debug.Log("jose2");
                keyMainDoor.SetActive(false);
            }

            else
            {
                keyMainDoor.SetActive(true);
            }
        }

        else
        {
            Debug.Log("jose4");
            keyMainDoor.SetActive(false);
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

    public void ButtonNPCBob()
    {
        if (bobStory == 1)
        {
            Debug.Log("owie2");

            Debug.Log("1xd");
            if (playerInRange)
            {
                dialogTextName.text = "Brother Bob:";
                dialogText.text = "I'm injured! Find me a med kit please! There should be one in the bathroom.";
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

        else if (bobStory == 2 && noMedKit.noMedkit == 2)
        {
            Debug.Log("owie2");

            Debug.Log("2xd");
            if (playerInRange)
            {
                dialogTextName.text = "Player:";
                dialogText.text = "We don't have med kit unfortunately.";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    bobStory = 3;

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

        else if (bobStory == 3)
        {
            Debug.Log("owie3");

            Debug.Log("3xd");
            if (playerInRange)
            {
                dialogTextName.text = "Brother Bob:";
                dialogText.text = "Go outside, look for help brother. Be careful on your way out. The key is inside the drawer right there.";
                Debug.Log("player range");

                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                    Debug.Log("dialog false");
                    checker = true;

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

        if (bobStory == 3 && checker && dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
            checker = false;
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
