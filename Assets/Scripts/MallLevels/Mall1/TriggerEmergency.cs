using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEmergency : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;
    [SerializeField]
    private GameObject questionBox;
    private int checker;

    public TriggerQuestion triggerQuestion;

    private void Awake()
    {
        checker = 0;
    }

    private void Update()
    {
        if (triggerQuestion.checkQuestion)
        {
            if (questionBox.activeInHierarchy)
            {
                if (checker == 0)
                {
                    dialogTextName.text = "Emergency Personnel:";
                    dialogText.text = "Please exit to the parking lot.";
                    dialogBox.SetActive(false);
                    checker = 1;
                }
            }

            else
            {
                if (checker == 1)
                {
                    dialogTextName.text = "Emergency Personnel:";
                    dialogText.text = "Please exit to the parking lot.";
                    dialogBox.SetActive(true);
                }
            }
        }
    }

    public void ButtonActionClose()
    {
        if (checker == 1)
        {
            dialogTextName.text = "Emergency Personnel:";
            dialogText.text = "Please exit to the parking lot.";
            checker = 2;

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }

            else
            {
                dialogBox.SetActive(true);
            }
        }
    }
}
