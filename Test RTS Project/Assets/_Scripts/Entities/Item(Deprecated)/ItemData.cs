using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{

	public Item itemObject;
	public string _itemName;
	public string _itemDescription;
	public Item.Type _itemType;

	// Use this for initialization
	void Start ()
	{
		_itemName = itemObject.itemName;
		_itemDescription = itemObject.description;
		_itemType = itemObject.type;
	}
}
