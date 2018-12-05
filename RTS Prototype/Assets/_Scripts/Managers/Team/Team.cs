using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Objects/Create New Team")]
public class Team : ScriptableObject
{

    public int teamNumber;
    public enum TeamAttribute {Neutral, Player, Enemy, Ally }
    public TeamAttribute teamAttribute;
    public Color Color = UnityEngine.Color.grey;
}
