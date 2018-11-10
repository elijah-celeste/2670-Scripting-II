using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public enum Type {Red, Yellow, Green, Blue }
    public Type type;
}
