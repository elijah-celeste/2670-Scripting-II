using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityData : MonoBehaviour
{
	public Entity entityObject;
	public Team team;
	public GameObject selectionCircle;
	public GameObject directionArrow;
	public NavMeshAgent agent;
	public bool isTasked;
	public GameObject assignedTask;
	public Animator anim;

	[Header("Current Values")] 
	public int currentHealth;
	
	[HideInInspector] public string objName;
	[HideInInspector] public bool isSelectable;
	[HideInInspector] public Entity.unitType type;
	[HideInInspector] public int baseHealth;
	[HideInInspector] public int baseDamage;
	[HideInInspector] public string description;
	[HideInInspector] public int value;
	
	void Awake () 
	{
		objName = entityObject.ObjName;
		isSelectable = entityObject.IsSelectable;
		type = entityObject.Type;
		baseHealth = entityObject.BaseHealth;
		baseDamage = entityObject.BaseDamage;
		description = entityObject.Description;
		value = entityObject.Value;
		currentHealth = baseHealth;
		
		if (objName == "Knight")
		{
			gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = team.Color;
			gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().color = team.Color;
			anim = gameObject.transform.GetChild(1).GetComponent<Animator>();
		}

		if (objName == "Town Center")
		{
			gameObject.GetComponent<MeshRenderer>().material.color = team.Color;
			gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = team.Color;
		}
	}
			
	void Update()
	{
		if (agent != null)
		{
			if (isTasked)
			{
				agent.SetDestination(assignedTask.transform.position);
			}
		}
	}

	//Receive Attack from External Source
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Attack") &&
		    other.GetComponentInParent<EntityData>() != null &&
		    other.GetComponentInParent<EntityData>().team.TeamAttribute != team.TeamAttribute)
		{
			GameObject parentObject = other.transform.parent.parent.gameObject;
			EntityData parEntData = parentObject.GetComponent<EntityData>();
			currentHealth -= parEntData.baseDamage;
			Debug.Log(name + " received damage " + parEntData.baseDamage + " from " + parentObject.name);
		}
	}
}
