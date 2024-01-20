using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSchoolOne : MonoBehaviour
{
    public bool levelTimer;
    public float currentTime = 0f;
    [SerializeField]
    private TextMeshProUGUI textTimer;

    public LevelComplete isComplete;

    void Awake()
    {
        levelTimer = false;
    }

    void Update()
    {
        if (levelTimer)
        {
            Debug.Log("time start");
            currentTime += 1 * Time.deltaTime;
            int intTimer = (int)currentTime;
            textTimer.text = " Timer: " + intTimer + " seconds";

            Debug.Log(currentTime);
        }
    }

/*    public void LevelClearShow()
    {
        if (isComplete.playerInRange)
        {
            Time.timeScale = 0f;

            textTimer.text = "Cleared in " + currentTime + " seconds!";
            showPanel.SetActive(true);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D insideQuestRange)
    {
        if (insideQuestRange.CompareTag("Player"))
        {

            levelTimer = true;
        }
    }
}
