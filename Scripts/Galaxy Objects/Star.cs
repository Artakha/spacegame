using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    
    public string starName;
    public bool scouted = false;
    public List<Planet> planets = new List<Planet>();
    public int energyOutput;

    private void OnMouseDown()
    {
        Debug.Log(starName);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
