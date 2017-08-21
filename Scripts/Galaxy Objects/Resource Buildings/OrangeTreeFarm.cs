using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeTreeFarm : ResourceBuilding {

    public OrangeTreeFarm(Planet aPlanet)
    {
        resourceBuildingName = "Orange Tree farm";
        foodPerMonth = 2;
        level = 1;
        maxLevel = 5;
        planet = aPlanet;
        currentWorkers = 0;
        maxWorkers = 8;
        metalsCost = 45;
        mainRes = "Food";
        upgradeCost = 65;
        energyCostPerMonth = 1.5;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
