using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerComplete : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogTextName;
    [SerializeField]
    private bool playerInRange;

    public NPCJonathan jonathan;
    public NPCTim tim;
    public NPCBernard bernard;

    [SerializeField]
    private GameObject activeJonathan;
    [SerializeField]
    private GameObject activeTim;
    [SerializeField]
    private GameObject activeBernard;

    [SerializeField]
    private GameObject fadeIn;
    [SerializeField]
    private GameObject fadeOut;
    [SerializeField]
    private Transform Target;

    private int gatherDialog;

    [SerializeField]
    private GameObject pushAnimation;
    [SerializeField]
    private GameObject hideBoulder;
    [SerializeField]
    private GameObject bernardAnimation;
    [SerializeField]
    private GameObject jonathanAnimation;

    private void Awake()
    {
        gatherDialog = 0;
    }

    private void Update()
    {
        if (activeJonathan.activeInHierarchy && activeTim.activeInHierarchy && activeBernard.activeInHierarchy)
        {
            Debug.Log("BRUHHHHHHHHHHHHHHHHH");

            if (gatherDialog == 0)
            {
                gatherDialog = 1;
            }

            if (gatherDialog == 1)
            {
                if (playerInRange)
                {
                    dialogTextName.text = "Player:";
                    dialogText.text = "Everyone's here, time to push the boulder now!";
                    Debug.Log("player range");
                    gatherDialog = 2;

                    if (dialogBox.activeInHierarchy)
                    {
                        dialogBox.SetActive(false);
                        Debug.Log("dialog false");
                    }

                    else
                    {
                        dialogBox.SetActive(true);
                        Debug.Log("dialog true");
                    }
                }
            }
        }
    }

    public void ButtonGather()
    {
        if (activeJonathan.activeInHierarchy && activeTim.activeInHierarchy && activeBernard.activeInHierarchy)
        {
            if (gatherDialog == 2)
            {
                if (playerInRange)
                {
                    dialogTextName.text = "Player:";
                    dialogText.text = "Everyone's here, time to push the boulder now!";
                    Debug.Log("player range");
                    gatherDialog = 3;

                    if (dialogBox.activeInHierarchy)
                    {
                        dialogBox.SetActive(false);
                        Debug.Log("dialog false");
                        StartCoroutine(GatherAnimation());
                    }

                    else
                    {
                        dialogBox.SetActive(true);
                        Debug.Log("dialog true");
                    }
                }
            }
        }
    }

    private IEnumerator GatherAnimation()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1f);
        Target.transform.position = new Vector3(34f, 24f, 0f);
        fadeOut.SetActive(true);

        hideBoulder.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        bernardAnimation.SetActive(false);
        jonathanAnimation.SetActive(false);

        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
        pushAnimation.SetActive(true);
        yield return new WaitForSeconds(8f);
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
}
