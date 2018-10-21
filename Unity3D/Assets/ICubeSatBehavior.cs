using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICubeSatSequence
{
    void StartSequence();
}

public interface ICubeSatSequenceCallback
{
    void SequenceComplete();
}

public interface IImageCapture
{
    IEnumerator BeginMovingOnPath(ICubeSatSequenceCallback callback);

    IEnumerator PerformImageCapture();
}