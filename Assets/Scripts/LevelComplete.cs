using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject fadeIn;
    [SerializeField]
    public bool playerInRange;
    [SerializeField]
    private TextMeshProUGUI textTimer;
    [SerializeField]
    private GameObject showPanel;
    [SerializeField]
    private GameObject starOne;
    [SerializeField]
    private GameObject starTwo;
    [SerializeField]
    private GameObject starThree;

    [SerializeField]
    private Button buttonNextLevel;

    public bool playSound;

    public AudioSource audioSource;

    public AudioClip Button, Dialog, LevelFinish;

    public TimerSchoolOne levelTimer;

    private int leverClearChecker;

    private void Awake()
    {
        playSound = true;
        leverClearChecker = 0;
    }

    void Update()
    {
        if (playerInRange)
        {
            StartCoroutine(LevelDone());
        }
    }

    public void ButtonLevelComplete()
    {
        if (playerInRange)
        {
            StartCoroutine(LevelDone());
        }
    }

    public IEnumerator LevelDone()
    {
        if (leverClearChecker == 1)
        {
            levelTimer.levelTimer = false;
            buttonNextLevel.interactable = false;

            if (playSound)
            {
                audioSource.clip = LevelFinish;
                audioSource.Play();
                playSound = false;
            }

            int intTimer = (int)levelTimer.currentTime;
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            int loadScore = 0;
            int threeStarTimer = 0;
            int twoStarTimer = 0;
            int oneStarTimer = 0;

            Debug.Log("Timer" + intTimer);

            if (currentLevel == 1)
            {
                loadScore = PlayerPrefs.GetInt("schoolLevelOneScore");
                threeStarTimer = 160;
                twoStarTimer = 160;
                oneStarTimer = 180;
            }

            else if (currentLevel == 2)
            {
                loadScore = PlayerPrefs.GetInt("schoolLevelTwoScore");
                threeStarTimer = 260;
                twoStarTimer = 260;
                oneStarTimer = 290;
            }

            else if (currentLevel == 3)
            {
                loadScore = PlayerPrefs.GetInt("schoolLevelThreeScore");
                threeStarTimer = 160;
                twoStarTimer = 160;
                oneStarTimer = 220;
            }

            else if (currentLevel == 4)
            {
                loadScore = PlayerPrefs.GetInt("houseLevelOneScore");
                threeStarTimer = 160;
                twoStarTimer = 160;
                oneStarTimer = 220;
            }

            else if (currentLevel == 5)
            {
                loadScore = PlayerPrefs.GetInt("houseLevelTwoScore");
                threeStarTimer = 120;
                twoStarTimer = 120;
                oneStarTimer = 180;
            }

            else if (currentLevel == 6)
            {
                loadScore = PlayerPrefs.GetInt("houseLevelThreeScore");
                threeStarTimer = 180;
                twoStarTimer = 180;
                oneStarTimer = 240;
            }

            else if (currentLevel == 7)
            {
                loadScore = PlayerPrefs.GetInt("mallLevelOneScore");
                threeStarTimer = 180;
                twoStarTimer = 180;
                oneStarTimer = 240;
            }

            else if (currentLevel == 8)
            {
                loadScore = PlayerPrefs.GetInt("mallLevelTwoScore");
                threeStarTimer = 180;
                twoStarTimer = 180;
                oneStarTimer = 240;
            }

            else if (currentLevel == 9)
            {
                loadScore = PlayerPrefs.GetInt("mallLevelThreeScore");
                threeStarTimer = 180;
                twoStarTimer = 180;
                oneStarTimer = 240;
            }

            textTimer.text = "Cleared in " + intTimer + " seconds!";
            fadeIn.SetActive(true);
            showPanel.SetActive(true);

            yield return new WaitForSeconds(1f);

            Debug.Log("Current Score:" + loadScore);

            if (intTimer < threeStarTimer)
            {
                if (currentLevel == 1)
                {
                    PlayerPrefs.SetInt("schoolLevelOneScore", 3);
                }

                else if (currentLevel == 2)
                {
                    PlayerPrefs.SetInt("schoolLevelTwoScore", 3);
                }

                else if (currentLevel == 3)
                {
                    PlayerPrefs.SetInt("schoolLevelThreeScore", 3);
                }

                else if (currentLevel == 4)
                {
                    PlayerPrefs.SetInt("houseLevelOneScore", 3);
                }

                else if (currentLevel == 5)
                {
                    PlayerPrefs.SetInt("houseLevelTwoScore", 3);
                }

                else if (currentLevel == 6)
                {
                    PlayerPrefs.SetInt("houseLevelThreeScore", 3);
                }

                else if (currentLevel == 7)
                {
                    PlayerPrefs.SetInt("mallLevelOneScore", 3);
                }

                else if (currentLevel == 8)
                {
                    PlayerPrefs.SetInt("mallLevelTwoScore", 3);
                }

                else if (currentLevel == 9)
                {
                    PlayerPrefs.SetInt("mallLevelThreeScore", 3);
                }

                starOne.SetActive(true);
                yield return new WaitForSeconds(1f);
                starTwo.SetActive(true);
                yield return new WaitForSeconds(1f);
                starThree.SetActive(true);
                yield return new WaitForSeconds(1f);
            }

            else if (intTimer >= twoStarTimer && intTimer <= oneStarTimer)
            {
                if (loadScore < 3)
                {
                    if (currentLevel == 1)
                    {
                        PlayerPrefs.SetInt("schoolLevelOneScore", 2);
                    }

                    else if (currentLevel == 2)
                    {
                        PlayerPrefs.SetInt("schoolLevelTwoScore", 2);
                    }

                    else if (currentLevel == 3)
                    {
                        PlayerPrefs.SetInt("schoolLevelThreeScore", 2);
                    }

                    else if (currentLevel == 4)
                    {
                        PlayerPrefs.SetInt("houseLevelOneScore", 2);
                    }

                    else if (currentLevel == 5)
                    {
                        PlayerPrefs.SetInt("houseLevelTwoScore", 2);
                    }

                    else if (currentLevel == 6)
                    {
                        PlayerPrefs.SetInt("houseLevelThreeScore", 2);
                    }

                    else if (currentLevel == 7)
                    {
                        PlayerPrefs.SetInt("mallLevelOneScore", 2);
                    }

                    else if (currentLevel == 8)
                    {
                        PlayerPrefs.SetInt("mallLevelTwoScore", 2);
                    }

                    else if (currentLevel == 9)
                    {
                        PlayerPrefs.SetInt("mallLevelThreeScore", 2);
                    }
                }

                starOne.SetActive(true);
                yield return new WaitForSeconds(1f);
                starTwo.SetActive(true);
                yield return new WaitForSeconds(1f);
            }

            else if (intTimer > oneStarTimer)
            {
                if (loadScore < 2)
                {
                    if (currentLevel == 1)
                    {
                        PlayerPrefs.SetInt("schoolLevelOneScore", 1);
                    }

                    else if (currentLevel == 2)
                    {
                        PlayerPrefs.SetInt("schoolLevelTwoScore", 1);
                    }

                    else if (currentLevel == 3)
                    {
                        PlayerPrefs.SetInt("schoolLevelThreeScore", 1);
                    }

                    else if (currentLevel == 4)
                    {
                        PlayerPrefs.SetInt("houseLevelOneScore", 1);
                    }

                    else if (currentLevel == 5)
                    {
                        PlayerPrefs.SetInt("houseLevelTwoScore", 1);
                    }

                    else if (currentLevel == 6)
                    {
                        PlayerPrefs.SetInt("houseLevelThreeScore", 1);
                    }

                    else if (currentLevel == 7)
                    {
                        PlayerPrefs.SetInt("mallLevelOneScore", 1);
                    }

                    else if (currentLevel == 8)
                    {
                        PlayerPrefs.SetInt("mallLevelTwoScore", 1);
                    }

                    else if (currentLevel == 9)
                    {
                        PlayerPrefs.SetInt("mallLevelThreeScore", 1);
                    }
                }

                starOne.SetActive(true);
                yield return new WaitForSeconds(1f);
            }

            if (currentLevel == 1)
            {
                loadScore = PlayerPrefs.GetInt("schoolLevelOneScore");
                Debug.Log(loadScore);

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 2)
            {
                loadScore = PlayerPrefs.GetInt("schoolLevelTwoScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 3)
            {
                loadScore = PlayerPrefs.GetInt("schoolLevelThreeScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 4)
            {
                loadScore = PlayerPrefs.GetInt("houseLevelOneScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 5)
            {
                loadScore = PlayerPrefs.GetInt("houseLevelTwoScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 6)
            {
                loadScore = PlayerPrefs.GetInt("houseLevelThreeScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 7)
            {
                loadScore = PlayerPrefs.GetInt("mallLevelOneScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 8)
            {
                loadScore = PlayerPrefs.GetInt("mallLevelTwoScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            else if (currentLevel == 9)
            {
                loadScore = PlayerPrefs.GetInt("mallLevelThreeScore");

                if (loadScore > 1)
                {
                    buttonNextLevel.interactable = true;
                }

                else
                {
                    buttonNextLevel.interactable = false;
                }
            }

            Debug.Log("XD");
            leverClearChecker = 2;
        }
     
        /*        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
    }

    public void SetMapSelectionOpen()
    {
        PlayerPrefs.SetInt("openMapSelection", 1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;

            if (leverClearChecker != 2)
            {
                leverClearChecker = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
