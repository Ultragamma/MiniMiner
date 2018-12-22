using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningLoc : MonoBehaviour
{
	public bool bActivated = false;

	public bool bMining = false;

	public int totalMinerals;

	int rand;

	public GameManager gMan;

	public InteracableObject intObj;

	// Start is called before the first frame update
	void Start()
	{
		gMan = FindObjectOfType<GameManager>();
		intObj = GetComponentInChildren<InteracableObject>();

		totalMinerals = Random.Range(100, 500);
	}

    // Update is called once per frame
    void Update()
    {
		if (bActivated && totalMinerals > 0 && gMan._inventory.hCurrent < gMan._inventory.hCapacity)
		{
			InvokeRepeating("Mining", 3, 3);
			bActivated = false;
		}
		if(intObj = null)
		{
			CancelInvoke("Mining");
			bMining = false;
			gMan._ui.information.enabled = false;
		}
		if(gMan._inventory.hCurrent >= gMan._inventory.hCapacity)
		{
			CancelInvoke("Mining");
			bMining = false;
			gMan._ui.information.enabled = false;
		}
	}



	void Mining()
	{
		//Activate Laser
		//Wait for Laser cycle to complete
		bMining = true;
		rand = Random.Range(3, 7);  //magic numbers
		gMan._inventory.hMinerals += rand;
		totalMinerals -= rand;
		gMan._ui.information.text = rand + " minerals mined.";
		gMan._ui.InfoFade();
	}
}
