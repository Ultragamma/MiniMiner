using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracableObject : MonoBehaviour
{
	public GameManager gMan;

	public bool bEngaged;
    // Start is called before the first frame update
    void Start()
    {
		gMan = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<ShipController>())
		{
			other.GetComponent<ShipController>().intObj = gameObject.GetComponent<InteracableObject>();
			other.GetComponent<ShipController>().bInteractable = true;
			if (GetComponentInParent<MiningLoc>() || GetComponentInParent<IceLoc>())
			{
				gMan._ui.instructions.text = "Press E to begin mining";
			}
			if (GetComponentInParent<StationLoc>() || GetComponentInParent<EventLoc>())
			{
				gMan._ui.instructions.text = "Press E to investigate";
			}
			if (GetComponentInParent<HubLoc>())
			{
				gMan._ui.instructions.text = "Press E to dock";
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (GetComponentInParent<MiningLoc>() || GetComponentInParent<IceLoc>())
		{
			//TODO block engagement if inventory full
			if (bEngaged)
			{
				gMan._ui.instructions.text = "Press E to stop mining";
			}
			
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<ShipController>())
		{
			other.GetComponent<ShipController>().intObj = null ;
			other.GetComponent<ShipController>().bInteractable = false;
			gMan._ui.instructions.text = "";
			if (gMan._ui.hubMenu.activeSelf)
			{
				gMan._ui.hubMenu.SetActive(false);
			}
		}
		Detach();
	}

	public void Interact()
	{	
		if (GetComponentInParent<MiningLoc>())
		{
			GetComponentInParent<MiningLoc>().bActivated = true;
		}
		if (GetComponentInParent<StationLoc>())
		{
			GetComponentInParent<StationLoc>().bActivated = true;
		}
		if (GetComponentInParent<EventLoc>())
		{
			GetComponentInParent<EventLoc>().bActivated = true;
		}
		if (GetComponentInParent<HubLoc>())
		{
			GetComponentInParent<HubLoc>().bActivated = true;
		}
		if (GetComponentInParent<IceLoc>())
		{
			GetComponentInParent<IceLoc>().bActivated = true;
		}
	}

	public void Detach()
	{
		if (GetComponentInParent<MiningLoc>())
		{
			GetComponentInParent<MiningLoc>().bActivated = false;
			GetComponentInParent<MiningLoc>().CancelInvoke("Mining");
			gMan._ship.StopCoroutine("FireLaser");
			gMan._ship.line.enabled = false;
			gMan._ship.bMining = false;
			gMan._ui.information.enabled = false;
		}
		if (GetComponentInParent<StationLoc>())
		{
			GetComponentInParent<StationLoc>().bActivated = false;
		}
		if (GetComponentInParent<EventLoc>())
		{
			GetComponentInParent<EventLoc>().bActivated = false;
		}
		if (GetComponentInParent<HubLoc>())
		{
			GetComponentInParent<HubLoc>().bActivated = false;
		}
		if (GetComponentInParent<IceLoc>())
		{
			GetComponentInParent<IceLoc>().bActivated = false;
		}
	}
}
