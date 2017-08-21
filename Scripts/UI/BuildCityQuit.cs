using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCityQuit : MonoBehaviour {

    public void onClick()
    {
        GameObject buildCity = GameObject.Find("UI/MainUI/CityBuilderPanel/BuildButton");
        Button buildCityButton = buildCity.GetComponent<Button>();
        buildCityButton.onClick.RemoveAllListeners();
        GameObject buildResBuilding = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildingButton");
        Button buildResourceBuilding = buildResBuilding.GetComponent<Button>();
        buildResourceBuilding.onClick.RemoveAllListeners();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
