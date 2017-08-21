using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbineField : ResourceBuilding {

    public WindTurbineField(Planet aPlanet)
    {
        resourceBuildingName = "Wind Turbine Field";
        energyPerMonth = 0.75;
        level = 1;
        maxLevel = 4;
        planet = aPlanet;
        currentWorkers = 0;
        maxWorkers = 6;
        metalsCost = 45;
        mainRes = "Energy";
        upgradeCost = 70;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
