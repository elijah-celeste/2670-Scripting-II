using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	void Update()
	{
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
	}
	
}
