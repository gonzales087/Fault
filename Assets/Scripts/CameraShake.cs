using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration = 0.2f;
    [SerializeField]
    private float shakeAmount = 0.1f;
    private bool isShaking = false;

    public EarthquakeTrigger earthquakeTrigger;
    public SecondEntranceBlock secondEntranceBlock;
    public WallBreak wallBreak;

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
        if (earthquakeTrigger.earthquakeStarted == 1 || earthquakeTrigger.earthquakeStarted == 2 || earthquakeTrigger.earthquakeStarted == 3)
        {
            ShakeIt();
        }

        if (secondEntranceBlock.earthquakeStarted == 1)
        {
            ShakeIt();
        }

        if (wallBreak.wallBreak == 1)
        {
            ShakeIt();
        }
    }
}
