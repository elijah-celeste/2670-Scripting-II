using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terrain/Create Terrain Type")]
public class WalkableTerrain : ScriptableObject
{

    public string terrainName;
    public enum Type {Walkable, NotWalkable}
    public Type type;
}
