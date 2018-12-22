using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour	
{
	public Camera _camera;

	public float _speed;

	Rigidbody rb;

	public bool bInteractable = false;

	public InteracableObject intObj;
	public InventoryController invCont;

	public int shipLevel = 0;

	// Start is called before the first frame update
	void Start()
    {
		_camera = Camera.main;
		rb = gameObject.GetComponent<Rigidbody>();
		invCont = GetComponentInChildren<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
		Movement();
		Interaction();
	}

	void Movement()
	{
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * _speed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.back * Time.deltaTime * _speed);
		}
		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(transform.up * _speed / 4);
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(-transform.up * _speed / 4);
		}
	}

	public void Interaction()
	{
		if (bInteractable)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (intObj != null)
				{
					intObj.Interact();
				}

			}
		}
	}

}
