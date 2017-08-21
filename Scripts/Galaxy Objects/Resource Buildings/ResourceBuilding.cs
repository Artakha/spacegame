using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding
{
    public string resourceBuildingName;
    public double metalsPerMonth;
    public double energyPerMonth;
    public double foodPerMonth;
    public int level;
    public int maxLevel;
    public Planet planet;
    public int currentWorkers;
    public int maxWorkers;
    public int metalsCost;
    public string mainRes;
    public int upgradeCost;
    public double energyCostPerMonth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public double GetMetalsPerMonth()
    {
        return metalsPerMonth;
    }

    public void SetMetalsPerMonth(double aMetalsPerMonth)
    {
        metalsPerMonth = aMetalsPerMonth;
    }

    public double GetEnergyPerMonth()
    {
        return energyPerMonth;
    }

    public void SetEnergyPerMonth(double aEnergyPerMonth)
    {
        energyPerMonth = aEnergyPerMonth;
    }

    public double GetFoodPerMonth()
    {
        return foodPerMonth;
    }

    public void SetFoodPerMonth(double aFoodPerMonth)
    {
        foodPerMonth = aFoodPerMonth;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int aLevel)
    {
        level = aLevel;
    }

    public string GetResourceBuildingName()
    {
        return resourceBuildingName;
    }

    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public Planet GetPlanet()
    {
        return planet;
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

    public string GetName()
    {
        return resourceBuildingName;
    }

    public int GetMetalsCost()
    {
        return metalsCost;
    }

    public string GetMainRes()
    {
        return mainRes;
    }

    public int GetUpgradeCost()
    {
        return upgradeCost;
    }

    public double GetEnergyCostPerMonth()
    {
        return energyCostPerMonth;
    }
}
