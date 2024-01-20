using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCJames : MonoBehaviour
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

    public EntranceOneBlock entranceOneBlock;

    [SerializeField]
    private Color buttonColor;
    [SerializeField]
    private Button[] buttonQuestion;
    [SerializeField]
    private Image[] buttonImage;

    private void Awake()
    {
        visualCue.SetActive(false);
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
    }
    
    public void ButtonNPCJames()
    {
        if (playerInRange)
        {
            dialogTextName.text = "James:";
            dialogText.text = "That shelf over there is not too heavy, you can push it to get out..";
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
        buttonImage[1].GetComponent<Image>().color = Color.red;
        StartCoroutine(WaitAnswer());

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
        yield return new WaitForSeconds(1f);
        buttonImage[0].GetComponent<Image>().color = Color.black;
        buttonImage[1].GetComponent<Image>().color = Color.black;
        buttonQuestion[0].interactable = true;
        buttonQuestion[1].interactable = true;
    }

    public IEnumerator WaitAnswerCorrect()
    {
        yield return new WaitForSeconds(1f);
        buttonImage[0].GetComponent<Image>().color = Color.black;
        buttonImage[1].GetComponent<Image>().color = Color.black;
        buttonQuestion[0].interactable = true;
        buttonQuestion[1].interactable = true;
        panelShowQuestion.SetActive(false);
    }
}
