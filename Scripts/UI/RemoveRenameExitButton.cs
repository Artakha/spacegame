using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveRenameExitButton : MonoBehaviour {

    public void OnClick()
    {
        GameObject renameButton = GameObject.Find("UI/MainUI/PlanetRenamePanel/RenameButton");
        Button renameB = renameButton.GetComponent<Button>();
        renameB.onClick.RemoveAllListeners();
        GameObject renameButton2 = GameObject.Find("UI/MainUI/CityRenamePanel/RenameButton");
        Button renameB2 = renameButton2.GetComponent<Button>();
        renameB2.onClick.RemoveAllListeners();
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
