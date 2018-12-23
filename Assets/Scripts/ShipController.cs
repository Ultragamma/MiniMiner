using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour	
{
	public Camera _camera;

	public float _speed;

	Rigidbody rb;

	public bool bInteractable = false;
	public bool bMining = false;

	public InteracableObject intObj;

	public InventoryController invCont;

	public ParticleSystem partSys;

	public LineRenderer line;

	public int shipLevel = 0;

	public GameManager gMan;

	// Start is called before the first frame update
	void Start()
    {
		gMan = FindObjectOfType<GameManager>();
		_camera = Camera.main;
		rb = gameObject.GetComponent<Rigidbody>();
		invCont = GetComponentInChildren<InventoryController>();
		partSys = GameObject.Find("sPartSys").GetComponent<ParticleSystem>();
		var em = partSys.emission;
		em.enabled = false;
		line = GetComponentInChildren<LineRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		Movement();
		Interaction();
		if (invCont.hCurrent >= invCont.hCapacity)
		{
			CancelInvoke("Mining");
			gMan._ship.StopCoroutine("FireLaser");
			gMan._ship.line.enabled = false;
			gMan._ui.information.enabled = false;
		}
	}

	void Movement()
	{
		var em = partSys.emission;
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
			rb.AddForce(transform.up * _speed / 8);
			em.enabled = true;
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(-transform.up * _speed / 8);
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			em.enabled = false;
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
					if (!intObj.bEngaged)
					{
						intObj.Interact();
						intObj.bEngaged = true;
						gMan._ui.information.enabled = true;
					} else
					{
						intObj.Detach();
						intObj.bEngaged = false;
						gMan._ui.information.enabled = false;
					}
				}
			}
		}
	}

	public IEnumerator FireLaser()
	{
		line.enabled = true;

		while (bMining)
		{
			Ray ray = new Ray(transform.position, intObj.transform.position);

			line.SetPosition(0, ray.origin);
			line.SetPosition(1, intObj.transform.position);

			yield return null;
		}
	}
}
