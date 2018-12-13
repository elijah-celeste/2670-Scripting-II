using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Objects/Create New Team")]
public class Team : ScriptableObject
{
    public int teamNumber;
    public enum teamAttribute {Neutral, Player, Enemy, Ally}
    public teamAttribute TeamAttribute;
    public Color Color = Color.gray;
}
