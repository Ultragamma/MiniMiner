using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public ShipController _ship;

	private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
		_ship = FindObjectOfType<ShipController>();
		offset = transform.position - _ship.transform.position;
	}

	// Update is called once per frame
	private void LateUpdate()
	{
		transform.position = _ship.transform.position + offset;
	}
}
