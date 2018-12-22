using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public ShipController _ship;
	public UIController _ui;
	public InventoryController _inventory;

    // Start is called before the first frame update
    void Start()
    {
		_ship = FindObjectOfType<ShipController>();
		_ui = FindObjectOfType<UIController>();
		_inventory = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
