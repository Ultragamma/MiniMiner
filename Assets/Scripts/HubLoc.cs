using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubLoc : MonoBehaviour
{
	public bool bActivated = false;
	public bool bDocked = false;

	public int hubLevel;

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
			if (!bDocked)
			{
				Dock();
			} else
			{
				Undock();
			}
		}
	}

	void Dock()
	{
		//Start docking animation
		//Wait for animation to complete
		//UI Popup with interaction choices
		//Repair/Equip
		//Research
		//Upgrade
		//Drop off Minerals
		print("Docking at the Hub");
		bDocked = true;
		gMan._ui.MenuPop(gMan._ui.hubMenu);
		bActivated = false;
	}

	void Undock()
	{
		print("Undocking from the Hub");
		bDocked = false;
		gMan._ui.MenuPop(gMan._ui.hubMenu);
		bActivated = false;
	}

	public void Unload()
	{
		gMan._inventory.dMinerals += gMan._inventory.hMinerals;
		gMan._inventory.hMinerals = 0;
		gMan._inventory.dWater += gMan._inventory.hWater;
		gMan._inventory.hWater = 0;
	}
}
