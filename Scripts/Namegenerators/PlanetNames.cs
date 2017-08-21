using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PlanetNames : MonoBehaviour {

    public static List<string> planetNames = new List<string>();

    // Use this for initialization
    void Start () {
        StreamReader sr = new StreamReader("Assets/Resources/Planetnames.txt");
        string fileContents = sr.ReadToEnd();
        sr.Close();

        string[] lines = fileContents.Split(","[0]);
        for(int i = 0; i < lines.Length; i++)
        {
            planetNames.Add(lines[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static string GetRandomPlanetName()
    {
        int toGet = Random.Range(0, planetNames.Count);
        string toReturn = planetNames.ElementAt(toGet);
        planetNames.RemoveAt(toGet);
        return toReturn;
    }

}
