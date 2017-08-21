using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityQuit : MonoBehaviour {

    GameObject cityBuildings;
    GameObject exitButton;
    GameObject exitButton2;

    public void onClick()
    {
        cityBuildings = GameObject.Find("UI/MainUI/CityPanel/CityBuildPanel/CityBuildings");
        foreach (Transform child in cityBuildings.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        exitButton = GameObject.Find("UI/MainUI/CityPanel/ExitButton");
        Button exitB = exitButton.GetComponent<Button>();
        exitB.onClick.RemoveAllListeners();
        exitButton2 = GameObject.Find("UI/MainUI/SpaceportPanel/ExitButton");
        Button exitB2 = exitButton2.GetComponent<Button>();
        exitB2.onClick.RemoveAllListeners();
        GameObject buildCityBuilding = GameObject.Find("UI/MainUI/CityPanel/CityBuildingButton");
        Button buildCitBuilding = buildCityBuilding.GetComponent<Button>();
        buildCitBuilding.onClick.RemoveAllListeners();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
