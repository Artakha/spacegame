using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

    public string moonName;
    public bool scouted = false;
    public Planet planetOrbiting;
    public double metalDeposit;
    List<ResourceBuilding> cityBuildings = new List<ResourceBuilding>();
    List<Microorganism> microorganismList = new List<Microorganism>();
    bool ice = false;
    bool water = false;

    private void OnMouseDown()
    {
        Debug.Log(moonName);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
