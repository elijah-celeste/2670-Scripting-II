using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Objects/Entities/Create New Entity Type")]
public class Entity : ScriptableObject
{
    public string ObjName;
    public enum UnitType {Unit, Building }
    public UnitType Type;
    public bool IsSelectable;
    public int BaseHealth;
    public int BaseDamage;
    [TextArea] public string Description;
    public int Value;
    public Color Color = Color.grey;
    public float defaultSpeed = 3.5f;
}
