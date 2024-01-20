using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeThree : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration = 0.2f;
    [SerializeField]
    private float shakeAmount = 0.1f;
    private bool isShaking = false;

    public EntranceOneBlock entranceOneBlock;
    public EntranceTwoBlock entranceTwoBlock;
    public EntranceThreeBlock entranceThreeBlock;
    public TriggerAfterShock triggerAfterShock;

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
        if (entranceOneBlock.earthquakeStarted == 1)
        {
            Debug.Log("shake 1");
            ShakeIt();
        }

        if (entranceTwoBlock.earthquakeStarted == 1)
        {
            Debug.Log("shake 2");
            ShakeIt();
        }

        if (entranceThreeBlock.earthquakeStarted == 1)
        {
            Debug.Log("shake 3");
            ShakeIt();
        }

        if (triggerAfterShock.earthquakeStarted == 2)
        {
            Debug.Log("shake 3");
            ShakeIt();
        }
    }
}
