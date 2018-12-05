using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

	public Vector3 tempPos;

	void Update()
	{
		tempPos = Input.mousePosition;
		tempPos.z = 0;
		transform.position = Camera.main.ScreenToWorldPoint(tempPos);
		Camera.
	}

}
