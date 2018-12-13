using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPointer : MonoBehaviour
{
	public float rotateSpeed = 10;
	public float lifeDuration = 2;
	public bool isRotator = false;

	void OnEnable()
	{
		StartCoroutine(AutoDisable());
	}
	
	void Update () {
		if (isRotator)
		{
			transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
		}
	
	}

	IEnumerator AutoDisable()
	{
		yield return new WaitForSeconds(lifeDuration);
		gameObject.SetActive(false);
	}
}
