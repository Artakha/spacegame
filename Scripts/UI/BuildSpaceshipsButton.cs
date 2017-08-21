using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSpaceshipsButton : MonoBehaviour {

    public void onClick()
    {
        GameObject industrialShipB = GameObject.Find("UI/MainUI/SpaceshipBuildPanel/SpaceshipBuildPanel/Spaceships/IndustrialTransportShip/Button");
        Button indB = industrialShipB.GetComponent<Button>();
        indB.onClick.RemoveAllListeners();
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
