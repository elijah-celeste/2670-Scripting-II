using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Objects/Entities/Create New Context")]
public abstract class Ability : ScriptableObject
{
    public string ButtonText = "Button";
    
    public abstract void doAbility(GameObject parent);
}
