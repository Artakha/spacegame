using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialTransportShip : Spaceship {

    public int metalsStorage;
    public int foodStorage;
    public int energyStorage;

    public IndustrialTransportShip(double speed, int metalsStorage, int foodStorage, int energyStorage)
    {
        this.speed = speed;
        this.metalsStorage = metalsStorage;
        this.foodStorage = foodStorage;
        this.energyStorage = energyStorage;
        shipName = "Industrial Transport Ship";
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public double GetSpeed()
    {
        return speed;
    }

    public int GetMetalsStorage()
    {
        return metalsStorage;
    }

    public int GetEnergyStorage()
    {
        return energyStorage;
    }

    public int GetFoodStorage()
    {
        return foodStorage;
    }

    

}
