using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public float panSpeed = 20f;
	
	void Update ()
	{

		Vector3 pos = transform.position;
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			pos.z += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			pos.z -= panSpeed * Time.deltaTime;
		}	
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += panSpeed * Time.deltaTime;
		}	
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= panSpeed * Time.deltaTime;
		}
		transform.position = pos;
	}
}
