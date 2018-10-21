using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightFlashBehavior : MonoBehaviour, IImageCapture
{
    public Light FlashLight;

    public float FlashStart = 10.0f;

    public float FadeStart = 5.0f;

    public float FadeEnd = 0.0f;

    public float FadeTime = 2.0f;


    void Start()
    {
        FlashLight.intensity = 0.0f;
    }

    public IEnumerator BeginMovingOnPath(ICubeSatSequenceCallback callback)
    {
        return GetComponent<MoveOnPath>().BeginMoving(this, callback);
    }

    public IEnumerator PerformImageCapture()
    {
        float time = 0.0f;

        while (time < FadeTime)
        {
            time += Time.deltaTime;

            FlashLight.intensity = Mathf.Lerp(FadeStart, FadeEnd, time / FadeTime);

            //arbitrarily returning an integer type
            yield return Enumerable.Empty<int>();
        }
    }
}
