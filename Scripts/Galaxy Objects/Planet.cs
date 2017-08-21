using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class Planet : MonoBehaviour {

    public string planetName;
    public bool scouted = false;
    public bool habitable = false;
    public bool capital = false;
    public Star starOrbiting;
    public List<Moon> moonList = new List<Moon>();
    public int metalDeposit;
    public string planetType;
    public List<int> speciesNumbers = new List<int>();
    public List<Microorganism> microorganismList = new List<Microorganism>();
    public List<City> cities = new List<City>();
    public int maxCities;
    public List<ResourceBuilding> resourceBuildings = new List<ResourceBuilding>();
    public int maxPop;
    public int currentMaxPop;
    public double currentMetals;
    public double currentEnergy;
    public double currentFood;
    public bool water;
    public bool ice;
    public int maxResourceBuildings;
    public int currentPop;
    public int currentUnemployedPop;
    public int uranium;
    public bool colonise;
    public double foodPerMonth;
    public double energyPerMonth;
    public double metalsPerMonth;
    public double happiness;
    public double maxFood;
    public double foodModifier;
    public double metalsModifier;
    public double energyModifier;
    public double energyCostRun;
    public List<Species> species = new List<Species>();
    public Spaceport spaceport;

    public GameObject planetPanel;
    public GameObject cityBuilderPanel;
    public GameObject planetCities;
    public GameObject planetRenamePanel;
    public GameObject planetResourceBuilderPanel;
    public GameObject cityBuildingError;
    public GameObject planetResourceBuildings;

    public GameObject energyResourceBuildings;

    public GameObject foodText;
    public GameObject metalsText;
    public GameObject energyText;
    public GameObject remainingMetalsText;
    public GameObject uniqueResourcesText;
    public GameObject populationText;
    public GameObject unemployedWorkersText;
    public GameObject happinessText;
    public GameObject waterIceText;
    public GameObject speciesText;

    public Sprite bSprite;


    // Use this for initialization
    void Start () {
        planetPanel = GameObject.Find("UI/MainUI/PlanetPanel");
        cityBuilderPanel = GameObject.Find("UI/MainUI/CityBuilderPanel");
        planetCities = GameObject.Find("UI/MainUI/PlanetPanel/Cities");
        planetRenamePanel = GameObject.Find("UI/MainUI/PlanetRenamePanel");
        planetResourceBuilderPanel = GameObject.Find("UI/MainUI/ResourceBuilderPanel");
        cityBuildingError = GameObject.Find("UI/MainUI/CityBuilderWarning");
        planetResourceBuildings = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildPanel/ResourceBuildings");
        bSprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        foodText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/FoodText");
        metalsText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/MetalsText");
        energyText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/EnergyText");
        remainingMetalsText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/RemainingMetalsText");
        uniqueResourcesText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/UniqueResourcesText");
        populationText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/PopulationText");
        unemployedWorkersText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/UnemployedWorkersText");
        happinessText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/HappinessText");
        waterIceText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/WaterIceText");
        speciesText = GameObject.Find("UI/MainUI/PlanetPanel/PlanetInfoPanel/SpeciesText");
        currentMaxPop = 100;
        happiness = 50;
        species.Add(Species.Elephant);
        speciesNumbers.Add(100);
        maxFood = 300;
    }

    private void OnMouseDown()
    {   

        if (!planetPanel.activeSelf && !cityBuilderPanel.activeSelf && !planetRenamePanel.activeSelf && !planetResourceBuilderPanel.activeSelf && !cityBuildingError.activeSelf && colonise)
        {
            Player.activePlanet = this;
            CityBuildingPanelLoad();
            
        }
    }


    // Update is called once per frame
    void Update () {
        
    }

    public void CityBuildingPanelLoad()
    {
        planetPanel.SetActive(true);
        GameObject planetNameBox = GameObject.Find("UI/MainUI/PlanetPanel/PlanetName");
        Text pText = planetNameBox.GetComponent<Text>();
        pText.text = planetName;
        for (int i = 0; i < cities.Count; i++)
        {
            GameObject button = new GameObject();
            button.transform.parent = planetCities.transform;
            button.AddComponent<RectTransform>();
            RectTransform rt = button.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(200, 50);
            button.AddComponent<Image>();
            button.AddComponent<Button>();
            Image img = button.GetComponent<Image>();
            img.sprite = bSprite;
            img.type = Image.Type.Sliced;
            GameObject text = new GameObject();
            text.transform.parent = button.transform;
            text.AddComponent<Text>();
            Text txt = text.GetComponent<Text>();
            txt.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            txt.color = Color.black;
            txt.alignment = TextAnchor.MiddleCenter;
            txt.text = cities.ElementAt(i).GetCityName();
            RectTransform ttext = text.GetComponent<RectTransform>();
            ttext.sizeDelta = new Vector2(200, 50);
            Button cityB = button.GetComponent<Button>();
            AddOnClickListenerToCityButton(cityB, cities.ElementAt(i));
        }
        GameObject buildCity = GameObject.Find("UI/MainUI/PlanetPanel/BuildCityButton");
        if (!habitable || cities.Count == maxCities)
        {
            buildCity.SetActive(false);
        }
        else if (habitable)
        {
            buildCity.SetActive(true);
            GameObject buildNewCity = GameObject.Find("UI/MainUI/CityBuilderPanel/BuildButton");
            Button buildCityButton = buildNewCity.GetComponent<Button>();
            buildCityButton.onClick.AddListener(delegate () { GetBuildCityName(); });
        }
        if (habitable)
        {
            GameObject citiesText = GameObject.Find("UI/MainUI/PlanetPanel/CitiesText");
            citiesText.SetActive(true);
            Text citiesTxt = citiesText.GetComponent<Text>();
            citiesTxt.text = ("Cities: " + cities.Count + "/" + maxCities);
        }
        GameObject renamePlanetButton = GameObject.Find("UI/MainUI/PlanetRenamePanel/RenameButton");
        Button renamePlanet = renamePlanetButton.GetComponent<Button>();
        renamePlanet.onClick.AddListener(delegate () { RenamePlanet(); });
        GameObject buildResourceBuilding = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildingButton");
        if (resourceBuildings.Count == maxResourceBuildings)
        {
            buildResourceBuilding.SetActive(false);
        }
        else
        {
            Button buildResBuilding = buildResourceBuilding.GetComponent<Button>();
            buildResBuilding.onClick.AddListener(delegate () { EligibleBuildings(); });
        }
        GameObject spaceportView = GameObject.Find("UI/MainUI/PlanetPanel/OpenSpaceport");
        Button svButton = spaceportView.GetComponent<Button>();
        svButton.onClick.AddListener(delegate () { spaceport.LoadSpaceport(); });
        ResourceBuildingLoad();
        DisplayPlanetResources();
    }

    public void ResourceBuildingLoad()
    {
        for (int i = 0; i < resourceBuildings.Count; i++)
        {
            ResourceBuilding currentR;
            GameObject resText = new GameObject();
            resText.layer = 5;
            resText.transform.parent = planetResourceBuildings.transform;
            resText.AddComponent<RectTransform>();
            RectTransform resT = resText.GetComponent<RectTransform>();
            resT.sizeDelta = new Vector2(260, 70);
            resText.AddComponent<Text>();
            Text resTxt = resText.GetComponent<Text>();
            resTxt.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            resTxt.color = Color.black;
            currentR = resourceBuildings.ElementAt(i);
            if(currentR.GetMainRes() == "Energy")
            {
                resTxt.text = " " + currentR.GetName() + "\n Level: " + currentR.GetLevel() + "/" + currentR.GetMaxLevel() + "        Workers: " + currentR.GetCurrentWorkers() + "/" + currentR.GetMaxWorkers() + "\n " + currentR.GetMainRes() + " per month: " + currentR.GetCurrentWorkers() * currentR.GetEnergyPerMonth();
            } else if (currentR.GetMainRes() == "Metals")
            {
                resTxt.text = " " + currentR.GetName() + "\n Level: " + currentR.GetLevel() + "/" + currentR.GetMaxLevel() + "        Workers: " + currentR.GetCurrentWorkers() + "/" + currentR.GetMaxWorkers() + "\n " + currentR.GetMainRes() + " per month: " + currentR.GetCurrentWorkers() * currentR.GetMetalsPerMonth();
            } else if (currentR.GetMainRes() == "Food")
            {
                resTxt.text = " " + currentR.GetName() + "\n Level: " + currentR.GetLevel() + "/" + currentR.GetMaxLevel() + "        Workers: " + currentR.GetCurrentWorkers() + "/" + currentR.GetMaxWorkers() + "\n " + currentR.GetMainRes() + " per month: " + currentR.GetCurrentWorkers() * currentR.GetFoodPerMonth();
            }
            
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
            prt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 197.5f, 25);
            prt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 34f, 25);
            mrt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 227.5f, 25);
            mrt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 34f, 25);
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
            pi.sprite = bSprite;
            pi.type = Image.Type.Sliced;
            Image mi = minusButton.GetComponent<Image>();
            mi.sprite = bSprite;
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
            urt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, 180);
            urt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 1f, 20);
            drt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 180f, 80);
            drt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 1f, 20);
            Text ub = ubText.GetComponent<Text>();
            Text db = dbText.GetComponent<Text>();
            ub.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            ub.color = Color.black;
            ub.alignment = TextAnchor.MiddleCenter;
            ub.text = "Upgrade: " + resourceBuildings.ElementAt(i).GetUpgradeCost() + " metals";
            RectTransform utloc = ubText.GetComponent<RectTransform>();
            utloc.sizeDelta = new Vector2(180, 20);
            db.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            db.color = Color.black;
            db.alignment = TextAnchor.MiddleCenter;
            db.text = "Destroy";
            RectTransform dtloc = dbText.GetComponent<RectTransform>();
            dtloc.sizeDelta = new Vector2(80, 20);
            Image ui = upgradeButton.GetComponent<Image>();
            ui.sprite = bSprite;
            ui.type = Image.Type.Sliced;
            Image di = destroyButton.GetComponent<Image>();
            di.sprite = bSprite;
            di.type = Image.Type.Sliced;
            Button destroyB = destroyButton.GetComponent<Button>();
            AddOnClickListenerToDestroy(destroyB, i);
            Button upgradeB = upgradeButton.GetComponent<Button>();
            AddOnClickListenerToUpgrade(upgradeB, i);
        }
        GameObject rbText = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildingsText");
        Text rbTxt = rbText.GetComponent<Text>();
        rbTxt.text = ("Resource Buildings: " + resourceBuildings.Count + "/" + maxResourceBuildings);
    }

    public void AddOnClickListenerToDestroy(Button button, int number)
    {
        button.onClick.AddListener(delegate () { DestroyResourceBuilding(number); });
    }

    public void AddOnClickListenerToUpgrade(Button button, int number)
    {
        button.onClick.AddListener(delegate () { UpgradeBuilding(number); });
        if (resourceBuildings.ElementAt(number).GetLevel() == resourceBuildings.ElementAt(number).GetMaxLevel())
        {
            button.gameObject.SetActive(false);
        }
    }

    public void UpgradeBuilding(int number)
    {
        ResourceBuilding toUpgrade = resourceBuildings.ElementAt(number);
        int currL = toUpgrade.GetLevel();
        int uCost = toUpgrade.GetUpgradeCost();
        if(currentMetals - uCost >= 0)
        {
            currentMetals = currentMetals - uCost;
            toUpgrade.SetLevel(currL + 1);
        }
        
        GameObject planetResourceBuildingsA = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildPanel/ResourceBuildings");
        foreach (Transform child in planetResourceBuildingsA.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        ResourceBuildingLoad();
        DisplayPlanetResources();
    }

    public void DestroyResourceBuilding(int number)
    {
        currentUnemployedPop = currentUnemployedPop + resourceBuildings.ElementAt(number).GetCurrentWorkers();
        resourceBuildings.RemoveAt(number);
        GameObject planetResourceBuildingsA = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildPanel/ResourceBuildings");
        foreach (Transform child in planetResourceBuildingsA.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        DisplayPlanetResources();
        ResourceBuildingLoad();
    }

    public void AddCity(City aCity)
    {
        cities.Add(aCity);
    }

    public void GetBuildCityName()
    {
        GameObject newCityName = GameObject.Find("UI/MainUI/CityBuilderPanel/CityName/Text");
        Text aNewCityName = newCityName.GetComponent<Text>();
        string newName = aNewCityName.text;
        if (newName == "")
        {
            newName = PlanetNames.GetRandomPlanetName();
        }
        if(newName == "")
            newName = "Sine Nomine";
        BuildCity(newName);
    }

    public void BuildCity(string cityName)
    {
        GameObject renameButton = GameObject.Find("UI/MainUI/PlanetRenamePanel/RenameButton");
        Button renameB = renameButton.GetComponent<Button>();
        renameB.onClick.RemoveAllListeners();
        if (currentMetals - 100 >= 0 && currentEnergy >= 0)
        {
            currentMetals = currentMetals - 100;
            currentEnergy = currentEnergy - 100;
            City city = new City(cityName, this);
            cities.Add(city);
            CityBuildingPanelLoad();
            planetPanel.SetActive(true);
        } else
        {
            GameObject cityBuildingError = GameObject.Find("UI/MainUI/CityBuilderWarning");
            cityBuildingError.SetActive(true);
        }
        
    }

    public void RenamePlanet()
    {
        GameObject newPlanetName = GameObject.Find("UI/MainUI/PlanetRenamePanel/PlanetNameInput/Text");
        Text aNewPlanetName = newPlanetName.GetComponent<Text>();
        string newName = aNewPlanetName.text;
        if (newName == "")
            newName = planetName;
        if (newName == "Sam Towes")
        {
            currentMetals += 2000;
            currentEnergy += 2000;
        }
        NewPlanetName(newName);
    }

    public void NewPlanetName(string newName)
    {
        GameObject renameButton = GameObject.Find("UI/MainUI/PlanetRenamePanel/RenameButton");
        Button renameB = renameButton.GetComponent<Button>();
        renameB.onClick.RemoveAllListeners();
        planetName = newName;
        CityBuildingPanelLoad();
        planetPanel.SetActive(true);
    }

    public double getMetals()
    {
        return currentMetals;
    }

    public void setMetals(double newMetals)
    {
        currentMetals = newMetals;
    }

    public double getEnergy()
    {
        return currentEnergy;
    }

    public void setEnergy(double newEnergy)
    {
        currentEnergy = newEnergy;
    }

    public double getFood()
    {
        return currentFood;
    }

    public void setFood(double newFood)
    {
        currentFood = newFood;
    }

    public void AddResourceBuilding(ResourceBuilding resourceBuilding)
    {
        GameObject renameButton = GameObject.Find("UI/MainUI/PlanetRenamePanel/RenameButton");
        Button renameB = renameButton.GetComponent<Button>();
        renameB.onClick.RemoveAllListeners();
        if (currentMetals - resourceBuilding.GetMetalsCost() >= 0)
        {
            currentMetals = currentMetals - resourceBuilding.GetMetalsCost();
            resourceBuildings.Add(resourceBuilding);
            CityBuildingPanelLoad();
        } else
        {
            GameObject cityBuildingError = GameObject.Find("UI/MainUI/CityBuilderWarning");
            cityBuildingError.SetActive(true);
        }
    }

    public void EligibleBuildings()
    {
        GameObject hydroButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/EnergyBuildPanel/ResourceBuildings/HydroelectricPowerPlant");
        GameObject windTButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/EnergyBuildPanel/ResourceBuildings/WindTurbineField");
        Button buildT = windTButton.GetComponent<Button>();
        GameObject mineShaftButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/MetalsBuildPanel/ResourceBuildings/MineShaft");
        Button buildMineShaft = mineShaftButton.GetComponent<Button>();
        GameObject orangeTreeFarmButton = GameObject.Find("UI/MainUI/ResourceBuilderPanel/FoodBuildPanel/ResourceBuildings/OrangeTreeFarm");
        Button buildOTreeF = orangeTreeFarmButton.GetComponent<Button>();
        hydroButton.SetActive(false);
        if (water)
        {
            hydroButton.SetActive(true);
            Button buildH = hydroButton.GetComponent<Button>();
            buildH.onClick.AddListener(delegate () { AddResourceBuilding(new HydroelectricPowerPlant(this)); });
        }
        if (uranium > 0 && currentPop >= 10)
        {
            //eligibleEnergyBuildings.Add("Nuclear Power Plant\nCost: 300 metals\nEnergy per month per worker: 3\nMax workers: 10");
        }
        //eligibleEnergyBuildings.Add("Solar Panel\nCost: 15 metals\nEnergy per month per worker: 1\nMax workers: 1");
        buildT.onClick.AddListener(delegate () { AddResourceBuilding(new WindTurbineField(this)); });
        buildMineShaft.onClick.AddListener(delegate () { AddResourceBuilding(new MineShaft(this)); });
        buildOTreeF.onClick.AddListener(delegate () { AddResourceBuilding(new OrangeTreeFarm(this)); });
    }

    public void DisplayPlanetResources()
    {
        string pf = "";
        string pm = "";
        string pe = "";
        if (Math.Floor(foodPerMonth + (foodPerMonth * foodModifier) - currentPop) >= 0)
            pf = "+";
        if (Math.Floor(metalsPerMonth + (metalsPerMonth * metalsModifier)) >= 0)
            pm = "+";
        if (Math.Floor(energyPerMonth + (energyPerMonth * energyModifier) - energyCostRun) >= 0)
            pe = "+";
        
        Text foodT = foodText.GetComponent<Text>();
        foodT.text = Math.Floor(currentFood) + pf + Math.Floor(foodPerMonth + (foodPerMonth * foodModifier) - currentPop);
        Text metalsT = metalsText.GetComponent<Text>();
        if(metalDeposit > 0)
        {
            metalsT.text = Math.Floor(currentMetals) + pm + Math.Floor(metalsPerMonth + (metalsPerMonth * metalsModifier));
        } else
        {
            metalsT.text = Math.Floor(currentMetals) + "+0";
        }
        
        Text energyT = energyText.GetComponent<Text>();
        energyT.text = Math.Floor(currentEnergy) + pe + Math.Floor(energyPerMonth + (energyPerMonth * energyModifier) - energyCostRun);
        Text remainingMetalsT = remainingMetalsText.GetComponent<Text>();
        remainingMetalsT.text = "Remaining       : " + metalDeposit;
        Text uniqueResourcesT = uniqueResourcesText.GetComponent<Text>();
        uniqueResourcesT.text = "Unique Resources: none";
        Text populationT = populationText.GetComponent<Text>();
        populationT.text = "Population: " + currentPop + "/" + currentMaxPop;
        Text unemployedWorkersT =  unemployedWorkersText.GetComponent<Text>();
        unemployedWorkersT.text = "Unemployed Workers: " + currentUnemployedPop;
        Text happinessT = happinessText.GetComponent<Text>();
        happinessT.text = "Happiness: " + Math.Floor(happiness);
        Text waterIceT = waterIceText.GetComponent<Text>();
        waterIceT.text = "Planet has " + WaterOrIce();
        Text speciesT = speciesText.GetComponent<Text>();
        speciesT.text = "Species: " + GetSpeciesNamesAndNumbers();
    }

    public string WaterOrIce()
    {
        string  waterOrIce = "";
        if (water)
        {
            waterOrIce = "water";
        } else if (ice) {
            waterOrIce = "ice";
        } else
        {
            waterOrIce = "neither water nor ice";
        }
        return waterOrIce;
    }

    public string GetSpeciesNamesAndNumbers()
    {
        string listOf = "";
        for(int i = 0; i < species.Count; i++)
        {
            listOf += speciesNumbers.ElementAt(i) + " " +  species.ElementAt(i) + "(s)";
        }
        return listOf;
    }

    public void UpdatePlanetForMonth()
    {   
        double mod = 1;
        currentFood = currentFood + foodPerMonth + (foodPerMonth * foodModifier) - currentPop;
        if (currentFood >= maxFood)
            currentFood = maxFood;
        if(metalDeposit > metalsPerMonth)
        {
            currentMetals += metalsPerMonth;
            metalDeposit = metalDeposit - (int)metalsPerMonth;
        } else if(metalDeposit <= metalsPerMonth)
        {
            currentMetals += metalDeposit;
            metalDeposit = 0;
        }
        
        currentEnergy += energyPerMonth;
        if(currentPop >= 40 && currentPop < 100)
        {
            mod = 0.5;
        } else if(currentPop >= 100 && currentPop < 200)
        {
            mod = 0.2;
        } else if(currentPop >= 200 && currentPop < 500)
        {
            mod = 0.1;
        } else if(currentPop >= 500)
        {
            mod = 0.05;
        }
        int increase = (int)((currentPop * Math.Sqrt(currentFood) / 90) * mod);
        if (increase < 1 && increase > 0 && currentFood > 0)
            increase = 1;
        currentPop = currentPop + increase;
        currentUnemployedPop = currentUnemployedPop + increase;
        currentMetals = currentMetals + (metalsPerMonth * metalsModifier);  
        currentEnergy = currentEnergy + (energyPerMonth * energyModifier) - energyCostRun;
    }

    public void UpdatePlanetForDay()
    {
        GetResourceBuildingsStats();
        GetCityInfo();
        DisplayPlanetResources();
    }

    public void GetResourceBuildingsStats()
    {
        double foodPerM = 0;
        double metalsPerM = 0;
        double energyPerM = 0;
        double energyCostPerM = 0;
        int cWorkers = 0;
        for(int i = 0; i < resourceBuildings.Count; i++)
        {
            ResourceBuilding resB = resourceBuildings.ElementAt(i);
            cWorkers = resB.GetCurrentWorkers();
            foodPerM += (resB.GetFoodPerMonth() * cWorkers);
            metalsPerM += (resB.GetMetalsPerMonth() * cWorkers);
            energyPerM += (resB.GetEnergyPerMonth() * cWorkers);
            energyCostPerM += resB.GetEnergyCostPerMonth();
        }
        foodPerMonth = foodPerM;
        metalsPerMonth = metalsPerM;
        energyPerMonth = energyPerM;
        energyCostRun = energyCostPerM;
    }

    public void GetCityInfo()
    {
        double foodMod = 0;
        double metalsMod = 0;
        double energyMod = 0;
        for(int i = 0; i < cities.Count; i++)
        {
            List<CityBuilding> cityBuildings = cities.ElementAt(i).GetCityBuildings();
            for(int j = 0; j < cityBuildings.Count(); j++)
            {
                CityBuilding cityB = cityBuildings.ElementAt(j);
                foodMod += cityB.GetFoodModifier() * cityB.GetCurrentWorkers() / 100;
                metalsMod += cityB.GetMetalsModifier() * cityB.GetCurrentWorkers() / 100;
                energyMod += cityB.GetEnergyModifier() * cityB.GetCurrentWorkers() / 100;
            }
        }
        foodModifier = foodMod;
        metalsModifier = metalsMod;
        energyModifier = energyMod;
    }

    public List<City> GetCities()
    {
        return cities;
    }

    public void AddOnClickListenertoAddWorker(Button button, int number)
    {
        button.onClick.AddListener(delegate () { AddWorker(number); });
    }

    public void AddWorker(int number)
    {
        ResourceBuilding toAdd = resourceBuildings.ElementAt(number);
        if(currentUnemployedPop > 0 && toAdd.GetCurrentWorkers() < toAdd.GetMaxWorkers())
        {
            currentUnemployedPop = currentUnemployedPop - 1;
            toAdd.SetCurrentWorkers(toAdd.GetCurrentWorkers() + 1);
        }
        
        GameObject planetResourceBuildingsA = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildPanel/ResourceBuildings");
        foreach (Transform child in planetResourceBuildingsA.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        ResourceBuildingLoad();
        DisplayPlanetResources();
    }

    public void AddOnClickListenertoRemoveWorker(Button button, int number)
    {
        button.onClick.AddListener(delegate () { RemoveWorker(number); });
    }

    public void RemoveWorker(int number)
    {
        ResourceBuilding toAdd = resourceBuildings.ElementAt(number);
        if (toAdd.GetCurrentWorkers() > 0)
        {
            currentUnemployedPop++;
            toAdd.SetCurrentWorkers(toAdd.GetCurrentWorkers() - 1);
        }

        GameObject planetResourceBuildingsA = GameObject.Find("UI/MainUI/PlanetPanel/ResourceBuildPanel/ResourceBuildings");
        foreach (Transform child in planetResourceBuildingsA.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        ResourceBuildingLoad();
        DisplayPlanetResources();
    }

    public void AddOnClickListenerToCityButton(Button button, City city)
    {
        button.onClick.AddListener(delegate () { city.OpenLoadCityPanel(); });
    }

    public int GetCurrentlyUnemployedPop()
    {
        return currentUnemployedPop;
    }

    public void SetCurrentlyUnemployedPop(int newNo)
    {
        currentUnemployedPop = newNo;
    }

    public void AddSpaceport(Spaceport spaceport)
    {
        this.spaceport = spaceport;
    }
}