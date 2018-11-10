using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainData : MonoBehaviour
{

	public WalkableTerrain terrainType;
	public WalkableTerrain.Type terrainAttribute;
	
	void Start ()
	{
		terrainAttribute = terrainType.type;
	}
}
