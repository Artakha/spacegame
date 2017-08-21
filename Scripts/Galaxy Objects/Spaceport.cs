using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Spaceport {
    //class to interact with spaceship panel and control spaceships between planets or other galaxy objects

    public List<Spaceship> spaceships = new List<Spaceship>();
    public Planet planet;
    public Sprite bSprite;

    public Spaceport(Planet planet)
    {
        this.planet = planet;
        bSprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSpaceship(Spaceship spaceship)
    {
        spaceships.Add(spaceship);
        GameObject spaceshipBuildButton = GameObject.Find("UI/MainUI/SpaceportPanel/SpaceshipBuildButton");
        Button spaceshipB = spaceshipBuildButton.GetComponent<Button>();
        spaceshipB.onClick.RemoveAllListeners();
        LoadSpaceport();
    }

    public List<Spaceship> GetSpaceships()
    {
        return spaceships;
    }

    public void BuildIndustrialShip()
    {
        IndustrialTransportShip indShip = new IndustrialTransportShip(2, 200, 150, 150);
        spaceships.Add(indShip);
        
    }

    public void LoadSpaceport()
    {
        GameObject spaceportSpaceships = GameObject.Find("UI/MainUI/SpaceportPanel/SpaceshipPanel/Spaceship");
        //do functionality for spaceships for moving between planets
        for (int i = 0; i < spaceships.Count; i++)
        {
            Spaceship currentS;
            GameObject resText = new GameObject();
            resText.layer = 5;
            resText.transform.parent = spaceportSpaceships.transform;
            resText.AddComponent<RectTransform>();
            RectTransform resT = resText.GetComponent<RectTransform>();
            resT.sizeDelta = new Vector2(260, 30);
            resText.AddComponent<Text>();
            Text resTxt = resText.GetComponent<Text>();
            resTxt.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            resTxt.color = Color.black;
            resTxt.alignment = TextAnchor.MiddleLeft;
            resTxt.fontSize = 16;
            currentS = spaceships.ElementAt(i);
            resTxt.text = currentS.GetName();
            GameObject sendButton = new GameObject();
            sendButton.layer = 5;
            sendButton.transform.parent = resText.transform;
            sendButton.AddComponent<Image>();
            sendButton.AddComponent<Button>();
            Button pButton = sendButton.GetComponent<Button>();
            GameObject pbText = new GameObject();
            pbText.transform.parent = sendButton.transform;
            pbText.AddComponent<Text>();
            RectTransform prt = sendButton.GetComponent<RectTransform>();
            prt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 200, 40);
            prt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 5, 20);
            Text pb = pbText.GetComponent<Text>();
            pb.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            pb.color = Color.black;
            pb.alignment = TextAnchor.MiddleCenter;
            pb.text = "Send";
            RectTransform ptloc = pbText.GetComponent<RectTransform>();
            ptloc.sizeDelta = new Vector2(40, 20);
            Image pi = sendButton.GetComponent<Image>();
            pi.sprite = bSprite;
            pi.type = Image.Type.Sliced;

        }
        GameObject spaceshipBuildButton = GameObject.Find("UI/MainUI/SpaceportPanel/SpaceshipBuildButton");
        Button spaceshipB = spaceshipBuildButton.GetComponent<Button>();
        spaceshipB.onClick.AddListener(delegate () { EligibleShips(); });
        GameObject exitButton = GameObject.Find("UI/MainUI/SpaceportPanel/ExitButton");
        Button exitB = exitButton.GetComponent<Button>();
        exitB.onClick.AddListener(delegate () { planet.CityBuildingPanelLoad(); });
    }

    public void EligibleShips()
    {
        GameObject indButton = GameObject.Find("UI/MainUI/SpaceshipBuildPanel/SpaceshipBuildPanel/Spaceships/IndustrialTransportShip/Button");
        Button indB = indButton.GetComponent<Button>();
        indB.onClick.AddListener(delegate () { AddSpaceship(new IndustrialTransportShip(0.15, 200, 150, 150)); });
        Debug.Log(spaceships.ElementAt(0));
    }
}
