using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Thank you Thomas Friday on Youtube for helping with the screen shake

public class ScreenShake : MonoBehaviour
{
    public float duration = .1f;
    public AnimationCurve curve;

    public IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
