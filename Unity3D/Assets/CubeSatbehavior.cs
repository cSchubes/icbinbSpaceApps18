using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSatbehavior : MonoBehaviour, ICubeSatSequence
{
    public GameObject CallbackSubscriber;
    private ICubeSatSequenceCallback _sequenceCompleteCallback;

    private IImageCapture _imgCapture;

	// Use this for initialization
	void Start() 
    {
        _imgCapture = GetComponent<IImageCapture>();
        _sequenceCompleteCallback = CallbackSubscriber.GetComponent<ICubeSatSequenceCallback>();
	}

    public void StartSequence()
    {
        Debug.Log("Sequence in progress");
        StartCoroutine(_imgCapture.BeginMovingOnPath(_sequenceCompleteCallback)); //DO work
    }
}
