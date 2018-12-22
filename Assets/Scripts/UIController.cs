using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameManager gMan;

	public Text hMineralsText;
	public Text hWaterText;
	public Text hPowerText;
	public Text dMineralsText;
	public Text dWaterText;
	public Text dPowerText;
	public Text dCurCap;
	public Text hCurCap;

	public Text instructions;

	public GameObject hubMenu;

	//public Text dronesText;
	//public Text minersText;
	//public Text haulersText;
	//public Text fightersText;

    // Start is called before the first frame update
    void Start()
    {
		gMan = FindObjectOfType<GameManager>();

		hubMenu.SetActive(false);

		//Hangar
		hMineralsText = GameObject.Find("hMineralsLabel").GetComponent<Text>();
		hWaterText = GameObject.Find("hWaterLabel").GetComponent<Text>();
		hPowerText = GameObject.Find("hPowerLabel").GetComponent<Text>();
		hCurCap = GameObject.Find("hCurCap").GetComponent<Text>();

		//Depot
		dMineralsText = GameObject.Find("dMineralsLabel").GetComponent<Text>();
		dWaterText = GameObject.Find("dWaterLabel").GetComponent<Text>();
		dPowerText = GameObject.Find("dPowerLabel").GetComponent<Text>();
		dCurCap = GameObject.Find("dCurCap").GetComponent<Text>();

		instructions = GameObject.Find("InstText").GetComponent<Text>();

		//dronesText = GameObject.Find("DronesLabel").GetComponent<Text>();
		//minersText = GameObject.Find("MinersLabel").GetComponent<Text>();
		//haulersText = GameObject.Find("HaulersLabel").GetComponent<Text>();
		//fightersText = GameObject.Find("FightersLabel").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
		//Hangar
		hMineralsText.text = gMan._inventory.hMinerals.ToString();
		hWaterText.text = gMan._inventory.hWater.ToString();
		hPowerText.text = gMan._inventory.hPower.ToString();
		hCurCap.text = gMan._inventory.hCurrent.ToString() + " / " + gMan._inventory.hCapacity.ToString();

		//Depot
		dMineralsText.text = gMan._inventory.dMinerals.ToString();
		dWaterText.text = gMan._inventory.dWater.ToString();
		dPowerText.text = gMan._inventory.dPower.ToString();
		dCurCap.text = gMan._inventory.dCurrent.ToString() + " / " + gMan._inventory.dCapacity.ToString();

		//dronesText.text = gMan._inventory.Drones.ToString();
		//minersText.text = gMan._inventory.Miners.ToString();
		//haulersText.text = gMan._inventory.Haulers.ToString();
		//fightersText.text = gMan._inventory.Fighters.ToString();

	}

	public void MenuPop(GameObject menu)
	{
		hubMenu.SetActive(!menu.activeSelf);
	}
}
