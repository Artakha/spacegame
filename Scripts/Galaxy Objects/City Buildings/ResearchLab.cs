using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchLab : CityBuilding {

    public ResearchLab(City aCity)
    {
        cityBuildingName = "Research Lab";
        societyResearch = 1;
        physicsResearch = 1;
        biologyResearch = 1;
        manufacturingResearch = 1;
        level = 1;
        maxLevel = 5;
        city = aCity;
        currentWorkers = 0;
        maxWorkers = 5;
        popReq = 0;
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
        string toReturn = "\nSociety+" + societyResearch * currentWorkers + "%  Physics+" + physicsResearch * currentWorkers + "%\nBiology+" + biologyResearch * currentWorkers + "%  Manufacturing+" + manufacturingResearch * currentWorkers;
        return toReturn;
    }
}
