using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class City {

    public List<CityBuilding> cityBuildings = new List<CityBuilding>();
    public bool capital = false;
    public Planet planet;
    public string cityName;
    public Mayor mayor;
    public int maxCityBuildings;
    public double societyResearch;
    public double physicsResearch;
    public double biologyResearch;
    public double manufacturingResearch;

    

    public City(string aName, Planet aPlanet)
    {
        cityName = aName;
        planet = aPlanet;
        mayor = new Mayor("Archbishop Guykit Lang");
        maxCityBuildings = 10;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuildEmpireCapital()
    {
        EmpireCapital empireCapital = new EmpireCapital(this);
        cityBuildings.Add(empireCapital);
    }

    public string GetCityName()
    {
        return cityName;
    }

    public List<CityBuilding> GetCityBuildings()
    {
        return cityBuildings;
    }

    public void OpenLoadCityPanel()
    {
        GameObject planetPanel = GameObject.Find("UI/MainUI/PlanetPanel");
        if(planetPanel.activeSelf)
            planetPanel.SetActive(false);
        GameObject cityPanel = GameObject.Find("UI/MainUI/CityPanel");
        cityPanel.SetActive(true);
        GameObject cityNameT = GameObject.Find("UI/MainUI/CityPanel/CityName");
        Text citynameText = cityNameT.GetComponent<Text>();
        citynameText.text = cityName;
        GameObject mayorNameT = GameObject.Find("UI/MainUI/CityPanel/MayorName");
        Text mayornameText = mayorNameT.GetComponent<Text>();
        mayornameText.text = mayor.GetMayorName();
        GameObject bCityBuildButton = GameObject.Find("UI/MainUI/CityPanel/CityBuildingButton");
        if (cityBuildings.Count == maxCityBuildings)
            bCityBuildButton.SetActive(false);
        GameObject exitButton = GameObject.Find("UI/MainUI/CityPanel/ExitButton");
        Button exitB = exitButton.GetComponent<Button>();
        exitB.onClick.AddListener(delegate () { planet.CityBuildingPanelLoad(); });
        GameObject renameCityButton = GameObject.Find("UI/MainUI/CityRenamePanel/RenameButton");
        Button renameCity = renameCityButton.GetComponent<Button>();
        renameCity.onClick.AddListener(delegate () { RenameCity(); });
        CityBuildingsLoad();
        DisplayCityResources();
    }

    public void CityBuildingsLoad()
    {
        GameObject cityCityBuildings = GameObject.Find("UI/MainUI/CityPanel/CityBuildPanel/CityBuildings");
        for (int i = 0; i < cityBuildings.Count; i++)
        {
            CityBuilding currentR;
            GameObject resText = new GameObject();
            resText.layer = 5;
            resText.transform.parent = cityCityBuildings.transform;
            resText.AddComponent<RectTransform>();
            RectTransform resT = resText.GetComponent<RectTransform>();
            resT.sizeDelta = new Vector2(256, 100);
            resT.anchoredPosition = new Vector2(50, 0);
            resText.AddComponent<Text>();
            Text resTxt = resText.GetComponent<Text>();
            resTxt.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            resTxt.color = Color.black;
            currentR = cityBuildings.ElementAt(i);
            resTxt.text = currentR.GetName() + "\nLevel: " + currentR.GetLevel() + "/" + currentR.GetMaxLevel() + "        " + "Workers: " + currentR.GetCurrentWorkers() + "/" + currentR.GetMaxWorkers() + currentR.DisplayResourcesString();
            GameObject plusButton = new GameObject();
            plusButton.layer = 5;
            plusButton.transform.parent = resText.transform;
            GameObject minusButton = new GameObject();
            minusButton.layer = 5;
            minusButton.transform.parent = resText.transform;
            plusButton.AddComponent<Image>();
            minusButton.AddComponent<Image>();
            plusButton.AddComponent<Button>();
            minusButton.AddComponent<Button>();
            Button pButton = plusButton.GetComponent<Button>();
            Button mButton = minusButton.GetComponent<Button>();
            AddOnClickListenertoAddWorker(pButton, i);
            AddOnClickListenertoRemoveWorker(mButton, i);
            GameObject pbText = new GameObject();
            GameObject mbText = new GameObject();
            pbText.transform.parent = plusButton.transform;
            mbText.transform.parent = minusButton.transform;
            pbText.AddComponent<Text>();
            mbText.AddComponent<Text>();
            RectTransform prt = plusButton.GetComponent<RectTransform>();
            RectTransform mrt = minusButton.GetComponent<RectTransform>();
            prt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 192.5f, 20);
            prt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 66.5f, 20);
            mrt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 222.5f, 20);
            mrt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 66.5f, 20);
            Text pb = pbText.GetComponent<Text>();
            Text mb = mbText.GetComponent<Text>();
            pb.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            pb.color = Color.black;
            pb.alignment = TextAnchor.MiddleCenter;
            pb.text = "+";
            RectTransform ptloc = pbText.GetComponent<RectTransform>();
            ptloc.sizeDelta = new Vector2(25, 25);
            mb.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            mb.color = Color.black;
            mb.alignment = TextAnchor.MiddleCenter;
            mb.text = "-";
            RectTransform mtloc = mbText.GetComponent<RectTransform>();
            mtloc.sizeDelta = new Vector2(25, 25);
            Image pi = plusButton.GetComponent<Image>();
            pi.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            pi.type = Image.Type.Sliced;
            Image mi = minusButton.GetComponent<Image>();
            mi.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            mi.type = Image.Type.Sliced;
            GameObject upgradeButton = new GameObject();
            upgradeButton.layer = 5;
            upgradeButton.transform.parent = resText.transform;
            GameObject destroyButton = new GameObject();
            destroyButton.layer = 5;
            destroyButton.transform.parent = resText.transform;
            upgradeButton.AddComponent<Image>();
            destroyButton.AddComponent<Image>();
            upgradeButton.AddComponent<Button>();
            destroyButton.AddComponent<Button>();
            GameObject ubText = new GameObject();
            GameObject dbText = new GameObject();
            ubText.transform.parent = upgradeButton.transform;
            dbText.transform.parent = destroyButton.transform;
            ubText.AddComponent<Text>();
            dbText.AddComponent<Text>();
            RectTransform urt = upgradeButton.GetComponent<RectTransform>();
            RectTransform drt = destroyButton.GetComponent<RectTransform>();
            urt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, -5f, 180);
            urt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 1f, 20);
            drt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 175f, 80);
            drt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 1f, 20);
            Text ub = ubText.GetComponent<Text>();
            Text db = dbText.GetComponent<Text>();
            ub.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            ub.color = Color.black;
            ub.alignment = TextAnchor.MiddleCenter;
            ub.text = "Upgrade: " + cityBuildings.ElementAt(i).GetUpgradeCost() + " metals";
            RectTransform utloc = ubText.GetComponent<RectTransform>();
            utloc.sizeDelta = new Vector2(180, 20);
            db.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            db.color = Color.black;
            db.alignment = TextAnchor.MiddleCenter;
            db.text = "Destroy";
            RectTransform dtloc = dbText.GetComponent<RectTransform>();
            dtloc.sizeDelta = new Vector2(80, 20);
            Image ui = upgradeButton.GetComponent<Image>();
            ui.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            ui.type = Image.Type.Sliced;
            Image di = destroyButton.GetComponent<Image>();
            di.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            di.type = Image.Type.Sliced;
            Button destroyB = destroyButton.GetComponent<Button>();
            //AddOnClickListenerToDestroy(destroyB, i);
            Button upgradeB = upgradeButton.GetComponent<Button>();
            //AddOnClickListenerToUpgrade(upgradeB, i);
        }
        GameObject cityBuildingsT = GameObject.Find("UI/MainUI/CityPanel/CityBuildingsText");
        Text cityBuildingsText = cityBuildingsT.GetComponent<Text>();
        cityBuildingsText.text = "City Buildings: " + cityBuildings.Count + "/" + maxCityBuildings;
        GameObject buildCityBuilding = GameObject.Find("UI/MainUI/CityPanel/CityBuildingButton");
        if (cityBuildings.Count == maxCityBuildings)
        {
            buildCityBuilding.SetActive(false);
        }
        else
        {
            Button buildResBuilding = buildCityBuilding.GetComponent<Button>();
            buildResBuilding.onClick.AddListener(delegate () { EligibleBuildings(); });
        }
    }

    public void AddOnClickListenertoAddWorker(Button button, int number)
    {
        button.onClick.AddListener(delegate () { AddWorker(number); });
    }

    public void AddWorker(int number)
    {
        CityBuilding toAdd = cityBuildings.ElementAt(number);
        int currentlyUnemployed = planet.GetCurrentlyUnemployedPop();
        if (currentlyUnemployed > 0 && toAdd.GetCurrentWorkers() < toAdd.GetMaxWorkers())
        {
            planet.SetCurrentlyUnemployedPop(currentlyUnemployed - 1);
            toAdd.SetCurrentWorkers(toAdd.GetCurrentWorkers() + 1);
        }

        GameObject cityCityBuildingsA = GameObject.Find("UI/MainUI/CityPanel/CityBuildPanel/CityBuildings");
        foreach (Transform child in cityCityBuildingsA.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        CityBuildingsLoad();
        DisplayCityResources();
    }

    public void AddOnClickListenertoRemoveWorker(Button button, int number)
    {
        button.onClick.AddListener(delegate () { RemoveWorker(number); });
    }

    public void RemoveWorker(int number)
    {
        CityBuilding toAdd = cityBuildings.ElementAt(number);
        if (toAdd.GetCurrentWorkers() > 0)
        {
            planet.SetCurrentlyUnemployedPop(planet.GetCurrentlyUnemployedPop() + 1);
            toAdd.SetCurrentWorkers(toAdd.GetCurrentWorkers() - 1);
        }

        GameObject cityCityBuildingsA = GameObject.Find("UI/MainUI/CityPanel/CityBuildPanel/CityBuildings");
        foreach (Transform child in cityCityBuildingsA.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        CityBuildingsLoad();
        DisplayCityResources();
    }

    public void DisplayCityResources()
    {
        GameObject cityInfo = GameObject.Find("UI/MainUI/CityPanel/CityInfo");
        Text cityInfoText = cityInfo.GetComponent<Text>();
        cityInfoText.text = "Society Research: 0\nPhysics Research: 0\nBiology Research: 0\nManufacturing Research: 0\n\nUnemployed Workers: " + planet.GetCurrentlyUnemployedPop();
    }

    public void UpdateCityForDay()
    {
        GetCityBuildingsStats();
        DisplayCityResources();
    }

    public void GetCityBuildingsStats()
    {
        double societyPerM = 0;
        double physicsPerM = 0;
        double biologyPerM = 0;
        double manufacturingPerM = 0;
        int cWorkers = 0;
        for (int i = 0; i < cityBuildings.Count; i++)
        {
            CityBuilding cityB = cityBuildings.ElementAt(i);
            cWorkers = cityB.GetCurrentWorkers();
            //societyPerM += (cityB.GetSocietyPerMonth() * cWorkers);
            //physicsPerM += (cityB.GetPhysicsPerMonth() * cWorkers);
            //biologyPerM += (cityB.GetBiologyPerMonth() * cWorkers);
            //manufacturingPerM += (cityB.GetManufacturingPerMonth() * cWorkers);
        }
        societyResearch = societyPerM;
        physicsResearch = physicsPerM;
        biologyResearch = biologyPerM;
        manufacturingResearch = manufacturingPerM;
    }

    public void RenameCity()
    {
        GameObject newCityName = GameObject.Find("UI/MainUI/CityRenamePanel/PlanetNameInput/Text");
        Text aNewCityName = newCityName.GetComponent<Text>();
        string newName = aNewCityName.text;
        if (newName == "")
            newName = cityName;
        NewCityName(newName);
    }

    public void NewCityName(string newName)
    {
        GameObject renameButton = GameObject.Find("UI/MainUI/CityRenamePanel/RenameButton");
        Button renameB = renameButton.GetComponent<Button>();
        renameB.onClick.RemoveAllListeners();
        cityName = newName;
        OpenLoadCityPanel();
        planet.ResourceBuildingLoad();
    }

    public void AddCityBuilding(CityBuilding cityBuilding)
    {
        GameObject renameButton = GameObject.Find("UI/MainUI/CityRenamePanel/RenameButton");
        Button renameB = renameButton.GetComponent<Button>();
        renameB.onClick.RemoveAllListeners();
        if (planet.currentMetals - cityBuilding.GetMetalsCost() >= 0)
        {
            planet.currentMetals = planet.currentMetals - cityBuilding.GetMetalsCost();
            cityBuildings.Add(cityBuilding);
            GameObject cityPanel = GameObject.Find("UI/MainUI/CityPanel");
            cityPanel.SetActive(true);
            OpenLoadCityPanel();
        }
        else
        {
            GameObject cityBuildingError = GameObject.Find("UI/MainUI/CityBuilderWarning");
            cityBuildingError.SetActive(true);
        }
    }

    public void EligibleBuildings()
    {
        GameObject researchLButton = GameObject.Find("UI/MainUI/CityBuildingBuildPanel/CityBuildingsPanel/CityBuildings/ResearchLab");
        Button researchL = researchLButton.GetComponent<Button>();
        researchL.onClick.AddListener(delegate () { AddCityBuilding(new ResearchLab(this)); });
    }
}
