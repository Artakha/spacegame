using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilding {

    public string cityBuildingName;
    public double metalsModifier;
    public double energyModifier;
    public double foodModifier;
    public int level;
    public int maxLevel;
    public City city;
    public int currentWorkers;
    public int maxWorkers;
    public int popReq;
    public double empirePoints;
    public int upgradeCost;
    public int energyCostPerMonth;
    public int metalsCost;
    public double societyResearch;
    public double physicsResearch;
    public double biologyResearch;
    public double manufacturingResearch;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public double GetMetalsModifier()
    {
        return metalsModifier;
    }

    public void SetMetalsModifier(double aMetalsModifier)
    {
        metalsModifier = aMetalsModifier;
    }

    public double GetEnergyModifier()
    {
        return energyModifier;
    }

    public void SetEnergyModifier(double aEnergyModifier)
    {
        energyModifier = aEnergyModifier;
    }

    public double GetFoodModifier()
    {
        return foodModifier;
    }

    public void SetFoodModifier(double aFoodModifier)
    {
        foodModifier = aFoodModifier;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int aLevel)
    {
        level = aLevel;
    }

    public double GetEmpirePoints()
    {
        return empirePoints;
    }
    
    public string GetName()
    {
        return cityBuildingName;
    }

    public int GetUpgradeCost()
    {
        return upgradeCost;
    }

    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public City GetCity()
    {
        return city;
    }

    public int GetCurrentWorkers()
    {
        return currentWorkers;
    }

    public void SetCurrentWorkers(int aCurrentWorkers)
    {
        currentWorkers = aCurrentWorkers;
    }

    public int GetMaxWorkers()
    {
        return maxWorkers;
    }

    public int GetMetalsCost()
    {
        return metalsCost;
    }

    public double GetEnergyCostPerMonth()
    {
        return energyCostPerMonth;
    }

    public virtual string DisplayResourcesString()
    {
        string toReturn = "\nMetals+" + metalsModifier * currentWorkers + "%  Energy+" + energyModifier * currentWorkers + "%  Food+" + foodModifier * currentWorkers + "%  Society+" + societyResearch * currentWorkers + "  Physics+" + physicsResearch * currentWorkers + "  Biology+" + biologyResearch * currentWorkers + "  Manufacturing+" + manufacturingResearch * currentWorkers;
        return toReturn;
    }

}
