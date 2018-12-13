using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Attack"))
		{
			Debug.Log("Hit" + this.gameObject.name);
		}
	}
}
