using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineShaft : ResourceBuilding {

    public MineShaft(Planet aPlanet)
    {
        resourceBuildingName = "Mine Shaft";
        metalsPerMonth = 2;
        level = 1;
        maxLevel = 5;
        planet = aPlanet;
        currentWorkers = 0;
        maxWorkers = 8;
        metalsCost = 70;
        mainRes = "Metals";
        upgradeCost = 85;
        energyCostPerMonth = 2;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
