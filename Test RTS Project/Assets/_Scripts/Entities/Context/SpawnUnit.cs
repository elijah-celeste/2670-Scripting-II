using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Objects/Entities/Create New Context/Spawner")]
public class SpawnUnit : Ability
{
	public override void doAbility(GameObject parent)
	{
		if (parent.GetComponent<EntityData>() != null)
		{
			Debug.Log("Entity Found");
		}
	}
}