using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityButtonQuit : MonoBehaviour {

    public GameObject planetCities;
    public GameObject planetResourceBuildings;

    public void onClick()
    {
        planetCities = GameObject.Find("UI/MainUI/PlanetPanel/Cities");
        foreach (Transform child in planetCities.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        planetResourceBuildings = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildPanel/ResourceBuildings");
        foreach (Transform child in planetResourceBuildings.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject buildCity = GameObject.Find("UI/MainUI/PlanetPanel/BuildCityButton");
        Button buildCityButton = buildCity.GetComponent<Button>();
        buildCityButton.onClick.RemoveAllListeners();
        GameObject buildResBuilding = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildingButton");
        Button buildResourceBuilding = buildResBuilding.GetComponent<Button>();
        buildResourceBuilding.onClick.RemoveAllListeners();
        GameObject spaceportView = GameObject.Find("UI/MainUI/PlanetPanel/OpenSpaceport");
        Button svButton = spaceportView.GetComponent<Button>();
        svButton.onClick.RemoveAllListeners();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
