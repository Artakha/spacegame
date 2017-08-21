using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public double societyResearch;
    public double societyResearchPerMonth;
    public double physicsResearch;
    public double physicsResearchPerMonth;
    public double biologyResearch;
    public double biologyResearchPerMonth;
    public double specialResearch;
    public double specialResearchPerMonth;

    public List<Planet> planets = new List<Planet>();

    public double policyPoints;
    public double policyPointsPerMonth;
    public double policyPointsModifier;
    public double empirePoints;
    public double empirePointsPerMonth;
    public double empirePointsModifier;
    GameObject empirePointsDisplay;
    Text ep;
    GameObject policyPointsDisplay;
    Text pp;
    GameObject dateDisplay;
    Text dd;

    public int day;
    public int month;
    public int year;

    public bool ready;

    public static Planet activePlanet;

    // Use this for initialization
    void Start () {
        ready = true;
        policyPoints = 0;
        policyPointsPerMonth = 1;
        policyPointsModifier = 1;
        empirePointsModifier = 1;
        GameObject startPlanet = GameObject.Find("Middleground/star1/planet1");
        Planet capitalPlanet = startPlanet.GetComponent(typeof(Planet)) as Planet;
        GameObject twoPlanet = GameObject.Find("Middleground/star1/planet2");
        Planet secondPlanet = twoPlanet.GetComponent(typeof(Planet)) as Planet;
        capitalPlanet.setMetals(300);
        capitalPlanet.setEnergy(200);
        capitalPlanet.setFood(100);
        City nova = new City("Nova", capitalPlanet);
        City vita = new City("Vita", capitalPlanet);
        nova.BuildEmpireCapital();
        capitalPlanet.cities.Add(nova);
        capitalPlanet.cities.Add(vita);
        Spaceport spaceport1 = new Spaceport(capitalPlanet);
        Spaceport spaceport2 = new Spaceport(secondPlanet);
        capitalPlanet.AddSpaceport(spaceport1);
        secondPlanet.AddSpaceport(spaceport2);
        empirePointsDisplay = GameObject.Find("UI/MainUI/TopScreenInfoUI/EmpirePointsDisplay");
        ep = empirePointsDisplay.GetComponent<Text>();
        policyPointsDisplay = GameObject.Find("UI/MainUI/TopScreenInfoUI/PolicyPointsDisplay");
        pp = policyPointsDisplay.GetComponent<Text>();
        dateDisplay = GameObject.Find("UI/MainUI/TopScreenInfoUI/DateDisplay");
        dd = dateDisplay.GetComponent<Text>();
        day = 0;
        month = 0;
        year = 0;
        planets.Add(capitalPlanet);
        planets.Add(secondPlanet);
        activePlanet = capitalPlanet;
    }
	
	// Update is called once per frame
	void Update () {
        if (ready)
        {
            StartCoroutine(UpdateAll());
        }
    }

    IEnumerator UpdateAll()
    {
        ready = false;
        day++;
        empirePointsPerMonth = GetEmpirePoints();
        UpdatePlanetForDay();
        if (day == 31)
        {
            day = 1;
            month++;
            policyPoints += policyPointsPerMonth * policyPointsModifier;
            empirePoints += empirePointsPerMonth * empirePointsModifier;
            UpdatePlanetResources();
        }
        if (month == 13)
        {
            month = 1;
            year++;
        }

        ep.text = "EP: " + Math.Floor(empirePoints) + "+" + Math.Floor(empirePointsPerMonth * empirePointsModifier);
        pp.text = "PP: " + Math.Floor(policyPoints) + "+" + Math.Floor(policyPointsPerMonth * policyPointsModifier);

        dd.text = day + "/" + month + "/" + year;
        yield return new WaitForSeconds(1); // 1 day = 1 second
        ready = true;
    }

    public void UpdatePlanetResources()
    {
        for(int i = 0; i < planets.Count; i++)
        {   
            planets.ElementAt(i).UpdatePlanetForMonth();
        }
    }

    public void UpdatePlanetForDay()
    {
        activePlanet.GetCityInfo();
        activePlanet.GetResourceBuildingsStats();
        activePlanet.DisplayPlanetResources();
    }

    public double GetEmpirePoints()
    {
        double empirePointsToAdd = 0;
        for(int i = 0; i < planets.Count; i++)
        {
            List<City> cities = planets.ElementAt(i).GetCities();
            for(int j = 0; j < cities.Count; j++)
            {
                List<CityBuilding> cityBuildings = cities.ElementAt(j).GetCityBuildings();
                for(int k = 0; k < cityBuildings.Count; k++)
                {
                    empirePointsToAdd += cityBuildings.ElementAt(k).GetEmpirePoints();
                }
            }
        }
        return empirePointsToAdd;
    }
}
