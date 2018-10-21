using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHologramComponent : MonoBehaviour {

    public GameObject Hologram;

    private bool _canShow = false;

    public void ShowHologram()
    {
        _canShow = true;
    }

    public void HideHologram()
    {
        _canShow = false;
    }

	// Use this for initialization
	void Start ()
    {
        ShowHologram();
       // HideHologram();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_canShow)
        {

            if (!Hologram.activeSelf)
            {
                Hologram.SetActive(true);
            }

            RotateHologram();
        }
        else
        {
            if (Hologram.activeSelf)
            {
                Hologram.SetActive(false);
            }
        }
	}

    private void RotateHologram()
    {
        Hologram.transform.Rotate(Vector3.up * Time.deltaTime * 15.0f);
    }
}
