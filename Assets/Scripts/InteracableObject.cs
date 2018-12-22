using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracableObject : MonoBehaviour
{
	public GameManager gMan;
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
			if (GetComponentInParent<MiningLoc>())
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
	}
}
