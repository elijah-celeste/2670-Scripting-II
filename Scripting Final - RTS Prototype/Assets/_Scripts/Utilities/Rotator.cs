using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public float rotateSpeed = 10;
	public bool isRotator = false;
	
	void Update () {
		if (isRotator)
		{
			transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
		}
	
	}
}
