using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeMallTwo : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration = 0.2f;
    [SerializeField]
    private float shakeAmount = 0.1f;
    private bool isShaking = false;

    public TriggerFirstBlock triggerFirstBlock;
    public TriggerFirstBlock triggerFirstBlockTwo;
    public TriggerFirstBlock triggerFirstBlockThree;
    public TriggerFirstBlock triggerFirstBlockFour;
    public TriggerFirstBlock triggerFirstBlockFive;
    public TriggerFirstBlock triggerFirstBlockSix;
    public TriggerFirstBlock triggerFirstBlockSeven;

    private IEnumerator Shake()
    {
        if (isShaking)
        {
            yield return null;
        }

        isShaking = true;
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        isShaking = false;
    }

    public void ShakeIt()
    {
        StartCoroutine(Shake());
    }

    private void Update()
    {
        if (triggerFirstBlock.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }

        if (triggerFirstBlockTwo.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }

        if (triggerFirstBlockThree.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }

        if (triggerFirstBlockFour.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }

        if (triggerFirstBlockFive.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }

        if (triggerFirstBlockSix.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }

        if (triggerFirstBlockSeven.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }
    }
}
