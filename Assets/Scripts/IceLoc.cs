using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLoc : MonoBehaviour
{
	public bool bActivated = false;

	public int totalWater;

	public GameManager gMan;
	// Start is called before the first frame update
	void Start()
	{
		gMan = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if (bActivated)
		{
			Mining();
		}
	}

	void Mining()
	{
		//Start mining animation
		//Wait for animation to complete
		gMan._inventory.hWater += 5;
		print("Got 5 water");
		bActivated = false;
	}
}
