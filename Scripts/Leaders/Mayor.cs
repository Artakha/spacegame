using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mayor {

    string mayorName;
    Image mayorImage;

    public Mayor(string aMayorName)
    {
        mayorName = aMayorName;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetMayorName()
    {
        return mayorName;
    }
}
