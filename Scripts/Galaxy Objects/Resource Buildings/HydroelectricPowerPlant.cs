using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroelectricPowerPlant : ResourceBuilding {



    public HydroelectricPowerPlant(Planet aPlanet)
    {
        resourceBuildingName = "Hydroelectric Power Plant";
        energyPerMonth = 1;
        level = 1;
        maxLevel = 5;
        planet = aPlanet;
        currentWorkers = 0;
        maxWorkers = 8;
        metalsCost = 80;
        mainRes = "Energy";
        upgradeCost = 100;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
