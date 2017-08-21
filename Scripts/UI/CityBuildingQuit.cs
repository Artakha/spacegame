using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityBuildingQuit : MonoBehaviour {

    public void onClick()
    {
        GameObject researchLButton = GameObject.Find("UI/MainUI/CityBuildingBuildPanel/CityBuildingsPanel/CityBuildings/ResearchLab");
        Button researchL = researchLButton.GetComponent<Button>();
        researchL.onClick.RemoveAllListeners();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
