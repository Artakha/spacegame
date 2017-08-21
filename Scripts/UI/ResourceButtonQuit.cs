using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButtonQuit : MonoBehaviour {


    

    public void onClick()
    {
        GameObject buildResBuilding = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildingButton");
        Button buildResourceBuilding = buildResBuilding.GetComponent<Button>();
        buildResourceBuilding.onClick.RemoveAllListeners();
        GameObject hydroButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/EnergyBuildPanel/ResourceBuildings/HydroelectricPowerPlant");
        Button buildH = hydroButton.GetComponent<Button>();
        buildH.onClick.RemoveAllListeners();
        GameObject windTButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/EnergyBuildPanel/ResourceBuildings/WindTurbineField");
        Button buildT = windTButton.GetComponent<Button>();
        buildT.onClick.RemoveAllListeners();
        GameObject mineSButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/MetalsBuildPanel/ResourceBuildings/MineShaft");
        Button buildms = mineSButton.GetComponent<Button>();
        buildms.onClick.RemoveAllListeners();
        GameObject orangeTreeFarmButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/FoodBuildPanel/ResourceBuildings/OrangeTreeFarm");
        Button buildOTreeF = orangeTreeFarmButton.GetComponent<Button>();
        buildOTreeF.onClick.RemoveAllListeners();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
