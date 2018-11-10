using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameManager : MonoBehaviour
{

	public Text cashtext;
	public float cashtotal = 0;

	void Start()
	{
		cashtext.text = "Cash: " + cashtotal;
	}
	
	void Update()
	{
		cashtext.text = "Cash: " + cashtotal;
	}
}
