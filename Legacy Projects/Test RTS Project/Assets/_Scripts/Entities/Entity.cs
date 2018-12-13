using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Objects/Entities/Create New EntityData")]
public class Entity : ScriptableObject
{
	public string ObjName;
	public enum unitType {Building, Unit }
	public bool IsSelectable;
	public unitType Type;
	public int BaseHealth;
	public int BaseDamage;
	[TextArea] public string Description;
	public int Value;
	public Color Color = Color.grey;
	public Ability[] Ability = new Ability[1];
	
//	public bool hasContextA;
//	public string textA;
//	public bool hasContextB;
//	public string textB;
//	public Context ContextA;
//	public Context ContextB;
}
