using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	[Header("Depot")]
	public int dCapacity;
	public int dCurrent;
	public int dMinerals;
	public int dWater;
	public int dPower;
	[Header("Hangar")]
	public int hCapacity;
	public int hCurrent;
	public int hMinerals;
	public int hWater;
	public int hPower;
	[Header("Ships")]
	public int Drones;
	public int Miners;
	public int Haulers;
	public int Fighters;
	[Header("People")]
	public int Crew;

	public List<string> Chracters;
	public List<string> Items;

	public UIController uiController;

	public bool bHangarFull = false;

	// Start is called before the first frame update
	void Start()
    {
		hCapacity = 50;
		dCapacity = 1000;
		hPower = 2;
		dPower = 10;
	}

    // Update is called once per frame
    void Update()
    {
		hCurrent = hMinerals + hWater;
		dCurrent = dMinerals + dWater;
		if(hCurrent >= hCapacity)
		{
			hCurrent = hCapacity;
			bHangarFull = true;
		}
		if (hCurrent <= hCapacity)
		{
			bHangarFull = false;
		}
			if (dCurrent >= dCapacity)
		{
			dCurrent = dCapacity;
		}
		if(hWater + hMinerals >= hCapacity)
		{
			hMinerals = hCapacity - hWater;
		}
	}

}
