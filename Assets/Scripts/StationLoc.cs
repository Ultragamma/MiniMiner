using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationLoc : MonoBehaviour
{
	public bool bActivated = false;

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
			StationEvent();
		}
    }

	void StationEvent()
	{
		//Generate UI object
		//Provide user with selection of event options
			//Recruitment
			//Salvage
			//Outpost
		print("We'll join you captain");
		bActivated = false;
	}
}
