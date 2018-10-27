using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHittingConsole : MonoBehaviour, ICubeSatSequenceCallback
{
    public GameObject ConsoleObject;
    public GameObject CubeSat;

    private ICubeSatSequence _cubeSat;

    private bool _pointingAtObject = false;
    private bool _isSequenceRunning = false;

	// Use this for initialization
	void Start () 
    {
        _pointingAtObject = false;
        _isSequenceRunning = false;

        _cubeSat = CubeSat.GetComponent<ICubeSatSequence>();
	}

    public void SequenceComplete()
    {
        Debug.Log("Sequence Completed");
        _isSequenceRunning = false;
    }


    void Update()
    {
        RaycastHit hit;
        //Debug.Log(transform.position);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log("Did Hit" + hit.transform.gameObject.name);

            _pointingAtObject = hit.transform.gameObject.name == ConsoleObject.name;

            if (_pointingAtObject)
            {
                if (Input.GetKeyDown(KeyCode.E) && !_isSequenceRunning)
                {
                    Debug.Log("Pressed E");

                    _isSequenceRunning = true;

                    _cubeSat.StartSequence();
                }
            }
        }
        else
        {
            _pointingAtObject = false;
        }
    }

    
    void OnGUI()
    {
        if (_pointingAtObject)
        {
            if (_isSequenceRunning)
            {
               GUI.Label(new Rect(Screen.width / 2, Screen.height / 4, 100, 100), "Inspection sequence is running...");
            }
            else
            {
               GUI.Label(new Rect(Screen.width / 2, Screen.height / 4, 100, 100), "Press E to start inspection sequence");
            }
        }
    }
}
