﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour {

	// Use this for initialization
	void Awake()
	{
		gameObject.SetActive(false);
	}
}
