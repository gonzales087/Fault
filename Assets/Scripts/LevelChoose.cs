using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChoose : MonoBehaviour
{
    public GameObject fadeIn;
    public AudioSource audioSource;

    [SerializeField]
    private GameObject mapSelection;

    // Game Object Lock
    [SerializeField]
    private GameObject lockOne;
    [SerializeField]
    private GameObject lockTwo;
    [SerializeField]
    private GameObject lockThree;
    [SerializeField]
    private GameObject lockFour;
    [SerializeField]
    private GameObject lockFive;
    [SerializeField]
    private GameObject lockSix;
    [SerializeField]
    private GameObject lockSeven;
    [SerializeField]
    private GameObject lockEight;

    // School Level Stars Variables
    [SerializeField]
    private GameObject schoolOne3Star;
    [SerializeField]
    private GameObject schoolOne2Star;
    [SerializeField]
    private GameObject schoolOne1Star;

    [SerializeField]
    private GameObject schoolTwo3Star;
    [SerializeField]
    private GameObject schoolTwo2Star;
    [SerializeField]
    private GameObject schoolTwo1Star;

    [SerializeField]
    private GameObject schoolThree3Star;
    [SerializeField]
    private GameObject schoolThree2Star;
    [SerializeField]
    private GameObject schoolThree1Star;

    // House Level Stars Variables
    [SerializeField]
    private GameObject houseOne3Star;
    [SerializeField]
    private GameObject houseOne2Star;
    [SerializeField]
    private GameObject houseOne1Star;

    [SerializeField]
    private GameObject houseTwo3Star;
    [SerializeField]
    private GameObject houseTwo2Star;
    [SerializeField]
    private GameObject houseTwo1Star;

    [SerializeField]
    private GameObject houseThree3Star;
    [SerializeField]
    private GameObject houseThree2Star;
    [SerializeField]
    private GameObject houseThree1Star;

    // Mall Level Stars Variables
    [SerializeField]
    private GameObject mallOne3Star;
    [SerializeField]
    private GameObject mallOne2Star;
    [SerializeField]
    private GameObject mallOne1Star;

    [SerializeField]
    private GameObject mallTwo3Star;
    [SerializeField]
    private GameObject mallTwo2Star;
    [SerializeField]
    private GameObject mallTwo1Star;

    [SerializeField]
    private GameObject mallThree3Star;
    [SerializeField]
    private GameObject mallThree2Star;
    [SerializeField]
    private GameObject mallThree1Star;

    // School Level Stars Variables
    [SerializeField]
    private Button buttonMapOne;
    [SerializeField]
    private Button buttonMapTwo;
    [SerializeField]
    private Button buttonMapThree;
    [SerializeField]
    private Button buttonMapFour;
    [SerializeField]
    private Button buttonMapFive;
    [SerializeField]
    private Button buttonMapSix;
    [SerializeField]
    private Button buttonMapSeven;
    [SerializeField]
    private Button buttonMapEight;
    [SerializeField]
    private Button buttonMapNine;

    public AudioClip Button;

    private void Awake()
    {
        fadeIn.SetActive(false);
    }

    private void Start()
    {
        ShowMapStars();

        int loadMap = PlayerPrefs.GetInt("openMapSelection");

        if (loadMap == 1) {
            mapSelection.SetActive(true);
        }
    }

    public void MapSelectionClose()
    {
        mapSelection.SetActive(false);
        PlayerPrefs.SetInt("openMapSelection", 0);
    }

    // Next Level Transition
    public void NextLevel()
    {
        audioSource.clip = Button;
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Scene Transitions Buttons: School
    public void SchoolLevelOneButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(SchoolLevelOne());
    }

    public void SchoolLevelTwoButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(SchoolLevelTwo());
    }

    public void SchoolLevelThreeButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(SchoolLevelThree());
    }

    // Scene Transitions Buttons: House
    public void HouseLevelOneButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(HouseLevelOne());
    }

    public void HouseLevelTwoButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(HouseLevelTwo());
    }

    public void HouseLevelThreeButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(HouseLevelThree());
    }

    // Scene Transitions Buttons: Mall
    public void MallLevelOneButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(MallLevelOne());
    }

    public void MallLevelTwoButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(MallLevelTwo());
    }

    public void MallLevelThreeButton()
    {
        audioSource.clip = Button;
        audioSource.Play();
        StartCoroutine(MallLevelThree());
    }

    // Scene Transitions: School
    public IEnumerator SchoolLevelOne()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public IEnumerator SchoolLevelTwo()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public IEnumerator SchoolLevelThree()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    // Scene Transitions: House
    public IEnumerator HouseLevelOne()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public IEnumerator HouseLevelTwo()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public IEnumerator HouseLevelThree()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }

    // Scene Transitions: Mall
    public IEnumerator MallLevelOne()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }

    public IEnumerator MallLevelTwo()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
    }

    public IEnumerator MallLevelThree()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
    }

    // Game Level to Main Menu Buttons (Male)
    public void SchoolLevelOneToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SchoolLevelTwoToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void SchoolLevelThreeToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void HouseLevelOneToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void HouseLevelTwoToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    public void HouseLevelThreeToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }

    public void MallLevelOneToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
    }

    public void MallLevelTwoToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 8);
    }

    public void MallLevelThreeToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
    }

    // Game Level to Main Menu Buttons (Female)
    public void SchoolLevelOneFemaleToMainMenu()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 10);
    }

    // Display Map Scores
    public void ShowMapStars()
    {
        int loadScoreSchoolOne = PlayerPrefs.GetInt("schoolLevelOneScore");

        int loadScoreSchoolTwo = PlayerPrefs.GetInt("schoolLevelTwoScore");

        int loadScoreSchoolThree = PlayerPrefs.GetInt("schoolLevelThreeScore");

        int loadScoreHouseOne = PlayerPrefs.GetInt("houseLevelOneScore");

        int loadScoreHouseTwo = PlayerPrefs.GetInt("houseLevelTwoScore");

        int loadScoreHouseThree = PlayerPrefs.GetInt("houseLevelThreeScore");

        int loadScoreMallOne = PlayerPrefs.GetInt("mallLevelOneScore");

        int loadScoreMallTwo = PlayerPrefs.GetInt("mallLevelTwoScore");

        int loadScoreMallThree = PlayerPrefs.GetInt("mallLevelThreeScore");

        //
        if (loadScoreSchoolOne > 1)
        {
            buttonMapTwo.interactable = true;
            lockOne.SetActive(false);
        }

        else
        {
            buttonMapTwo.interactable = false;
            lockOne.SetActive(true);
        }

        //
        if (loadScoreSchoolTwo > 1)
        {
            buttonMapThree.interactable = true;
            lockTwo.SetActive(false);
        }

        else
        {
            buttonMapThree.interactable = false;
            lockTwo.SetActive(true);
        }

        //
        if (loadScoreSchoolThree > 1)
        {
            buttonMapFour.interactable = true;
            lockThree.SetActive(false);
        }

        else
        {
            buttonMapFour.interactable = false;
            lockThree.SetActive(true);
        }

        //
        if (loadScoreHouseOne > 1)
        {
            buttonMapFive.interactable = true;
            lockFour.SetActive(false);
        }

        else
        {
            buttonMapFive.interactable = false;
            lockFour.SetActive(true);
        }

        //
        if (loadScoreHouseTwo > 1)
        {
            buttonMapSix.interactable = true;
            lockFive.SetActive(false);
        }

        else
        {
            buttonMapSix.interactable = false;
            lockFive.SetActive(true);
        }

        //
        if (loadScoreHouseThree > 1)
        {
            buttonMapSeven.interactable = true;
            lockSix.SetActive(false);
        }

        else
        {
            buttonMapSeven.interactable = false;
            lockSix.SetActive(true);
        }

        //
        if (loadScoreMallOne > 1)
        {
            buttonMapEight.interactable = true;
            lockSeven.SetActive(false);
        }

        else
        {
            buttonMapEight.interactable = false;
            lockSeven.SetActive(true);
        }

        //
        if (loadScoreMallTwo > 1)
        {
            buttonMapNine.interactable = true;
            lockEight.SetActive(false);
        }

        else
        {
            buttonMapNine.interactable = false;
            lockEight.SetActive(true);
        }

        switch (loadScoreSchoolOne)
        {
            case 1:
                schoolOne3Star.SetActive(false);
                schoolOne2Star.SetActive(false);
                schoolOne1Star.SetActive(true);
                break;
            case 2:
                schoolOne3Star.SetActive(false);
                schoolOne2Star.SetActive(true);
                schoolOne1Star.SetActive(true);
                break;
            case 3:
                schoolOne3Star.SetActive(true);
                schoolOne2Star.SetActive(true);
                schoolOne1Star.SetActive(true);
                break;
            default:
                schoolOne3Star.SetActive(false);
                schoolOne2Star.SetActive(false);
                schoolOne1Star.SetActive(false);
                break;
        }

        switch (loadScoreSchoolTwo)
        {
            case 1:
                schoolTwo3Star.SetActive(false);
                schoolTwo2Star.SetActive(false);
                schoolTwo1Star.SetActive(true);
                break;
            case 2:
                schoolTwo3Star.SetActive(false);
                schoolTwo2Star.SetActive(true);
                schoolTwo1Star.SetActive(true);
                break;
            case 3:
                schoolTwo3Star.SetActive(true);
                schoolTwo2Star.SetActive(true);
                schoolTwo1Star.SetActive(true);
                break;
            default:
                schoolTwo3Star.SetActive(false);
                schoolTwo2Star.SetActive(false);
                schoolTwo1Star.SetActive(false);
                break;
        }

        switch (loadScoreSchoolThree)
        {
            case 1:
                schoolThree3Star.SetActive(false);
                schoolThree2Star.SetActive(false);
                schoolThree1Star.SetActive(true);
                break;
            case 2:
                schoolThree3Star.SetActive(false);
                schoolThree2Star.SetActive(true);
                schoolThree1Star.SetActive(true);
                break;
            case 3:
                schoolThree3Star.SetActive(true);
                schoolThree2Star.SetActive(true);
                schoolThree1Star.SetActive(true);
                break;
            default:
                schoolThree3Star.SetActive(false);
                schoolThree2Star.SetActive(false);
                schoolThree1Star.SetActive(false);
                break;
        }

        switch (loadScoreHouseOne)
        {
            case 1:
                houseOne3Star.SetActive(false);
                houseOne2Star.SetActive(false);
                houseOne1Star.SetActive(true);
                break;
            case 2:
                houseOne3Star.SetActive(false);
                houseOne2Star.SetActive(true);
                houseOne1Star.SetActive(true);
                break;
            case 3:
                houseOne3Star.SetActive(true);
                houseOne2Star.SetActive(true);
                houseOne1Star.SetActive(true);
                break;
            default:
                houseOne3Star.SetActive(false);
                houseOne2Star.SetActive(false);
                houseOne1Star.SetActive(false);
                break;
        }

        switch (loadScoreHouseTwo)
        {
            case 1:
                houseTwo3Star.SetActive(false);
                houseTwo2Star.SetActive(false);
                houseTwo1Star.SetActive(true);
                break;
            case 2:
                houseTwo3Star.SetActive(false);
                houseTwo2Star.SetActive(true);
                houseTwo1Star.SetActive(true);
                break;
            case 3:
                houseTwo3Star.SetActive(true);
                houseTwo2Star.SetActive(true);
                houseTwo1Star.SetActive(true);
                break;
            default:
                houseTwo3Star.SetActive(false);
                houseTwo2Star.SetActive(false);
                houseTwo1Star.SetActive(false);
                break;
        }

        switch (loadScoreHouseThree)
        {
            case 1:
                houseThree3Star.SetActive(false);
                houseThree2Star.SetActive(false);
                houseThree1Star.SetActive(true);
                break;
            case 2:
                houseThree3Star.SetActive(false);
                houseThree2Star.SetActive(true);
                houseThree1Star.SetActive(true);
                break;
            case 3:
                houseThree3Star.SetActive(true);
                houseThree2Star.SetActive(true);
                houseThree1Star.SetActive(true);
                break;
            default:
                houseThree3Star.SetActive(false);
                houseThree2Star.SetActive(false);
                houseThree1Star.SetActive(false);
                break;
        }

        switch (loadScoreMallOne)
        {
            case 1:
                mallOne3Star.SetActive(false);
                mallOne2Star.SetActive(false);
                mallOne1Star.SetActive(true);
                break;
            case 2:
                mallOne3Star.SetActive(false);
                mallOne2Star.SetActive(true);
                mallOne1Star.SetActive(true);
                break;
            case 3:
                mallOne3Star.SetActive(true);
                mallOne2Star.SetActive(true);
                mallOne1Star.SetActive(true);
                break;
            default:
                mallOne3Star.SetActive(false);
                mallOne2Star.SetActive(false);
                mallOne1Star.SetActive(false);
                break;
        }

        switch (loadScoreMallTwo)
        {
            case 1:
                mallTwo3Star.SetActive(false);
                mallTwo2Star.SetActive(false);
                mallTwo1Star.SetActive(true);
                break;
            case 2:
                mallTwo3Star.SetActive(false);
                mallTwo2Star.SetActive(true);
                mallTwo1Star.SetActive(true);
                break;
            case 3:
                mallTwo3Star.SetActive(true);
                mallTwo2Star.SetActive(true);
                mallTwo1Star.SetActive(true);
                break;
            default:
                mallTwo3Star.SetActive(false);
                mallTwo2Star.SetActive(false);
                mallTwo1Star.SetActive(false);
                break;
        }

        switch (loadScoreMallThree)
        {
            case 1:
                mallThree3Star.SetActive(false);
                mallThree2Star.SetActive(false);
                mallThree1Star.SetActive(true);
                break;
            case 2:
                mallThree3Star.SetActive(false);
                mallThree2Star.SetActive(true);
                mallThree1Star.SetActive(true);
                break;
            case 3:
                mallThree3Star.SetActive(true);
                mallThree2Star.SetActive(true);
                mallThree1Star.SetActive(true);
                break;
            default:
                mallThree3Star.SetActive(false);
                mallThree2Star.SetActive(false);
                mallThree1Star.SetActive(false);
                break;
        }
    }

    // Exit Button
    public void ExitGame()
    {
        audioSource.clip = Button;
        audioSource.Play();
        Application.Quit();
    }
}
