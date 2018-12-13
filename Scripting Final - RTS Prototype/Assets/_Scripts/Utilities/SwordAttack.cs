using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
	public EntityController controller;

	public void AttackHit()
	{
		controller.GiveDamage();
	}
}
