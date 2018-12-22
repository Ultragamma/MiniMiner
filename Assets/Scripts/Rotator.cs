using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
		transform.Rotate(Vector3.forward * Time.deltaTime * 5);
		transform.Rotate(Vector3.right * Time.deltaTime * 2);
		transform.Rotate(Vector3.up * Time.deltaTime * 3);
    }
}
