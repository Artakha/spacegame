using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireCapital : CityBuilding {


    public EmpireCapital(City aCity)
    {
        cityBuildingName = "Empire Capital";
        metalsModifier = 0.5;
        energyModifier  = 0.5;
        foodModifier = 0.5;
        level = 1;
        maxLevel = 5;
        city = aCity;
        currentWorkers = 0;
        maxWorkers = 10;
        popReq = 0;
        empirePoints = 1;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    override
    public string DisplayResourcesString()
    {
        string toReturn = "\nMetals+" + metalsModifier * currentWorkers + "%  Energy+" + energyModifier * currentWorkers + "%\nFood+" + foodModifier * currentWorkers + "%  Empire Points+" + empirePoints;
        return toReturn;
    }

}
