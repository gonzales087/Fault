using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MallLevelOne : MonoBehaviour
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
    public AudioClip EarthquakeBlockDebris, Debris, Button, Dialog, Music;

    private void Awake()
    {
        dialogTextName.text = "Player:";
        dialogText.text = "I need to go home.";
        closeDialog = 0;
        fadeOut.SetActive(false);
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
}
