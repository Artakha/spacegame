using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveSpaceshipsL : MonoBehaviour {

    public void onClick()
    {
        GameObject spaceportView = GameObject.Find("UI/MainUI/PlanetPanel/OpenSpaceport");
        Button svButton = spaceportView.GetComponent<Button>();
        svButton.onClick.RemoveAllListeners();
        GameObject spaceshipBuildButton = GameObject.Find("UI/MainUI/SpaceportPanel/SpaceshipBuildButton");
        Button spaceshipB = spaceshipBuildButton.GetComponent<Button>();
        spaceshipB.onClick.RemoveAllListeners();
        GameObject spaceships = GameObject.Find("UI/MainUI/SpaceportPanel/SpaceshipPanel/Spaceship");
        foreach (Transform child in spaceships.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
