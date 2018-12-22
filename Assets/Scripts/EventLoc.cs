using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoc : MonoBehaviour
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
			StoryEvent();
		}
	}

	void StoryEvent()
	{
		//Generate UI object
		//Provide actions to user
		//Action outcomes
		print("I have learned something of the Universe");
		bActivated = false;
	}
}
