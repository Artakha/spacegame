using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Governor : MonoBehaviour {

    string governorName;
    Image mayorImage;

    public Governor(string aGovernorName)
    {
        governorName = aGovernorName;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetGovernorName()
    {
        return governorName;
    }
}
