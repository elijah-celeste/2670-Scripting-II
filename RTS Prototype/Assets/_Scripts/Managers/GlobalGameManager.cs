using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalGameManager : MonoBehaviour
{

	public float timer;
	public Text timerText;
	
	void Update ()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else if (timer <= 0)
		{
			timer = 0;
		}

		timerText.text = string.Format("TIME: {0:#.00}", timer);
	}
}
