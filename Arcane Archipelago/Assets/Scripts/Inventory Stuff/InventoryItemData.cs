using UnityEngine;
using System;

[CreateAssetMenu (fileName = "Inv Item", menuName = "Inventory/Add Item", order = 0)]
public class InventoryItemData : ScriptableObject
{
	public string displayName;
	public enum Categories {
		Resource, Tool, Spell
	}
	public Categories category;
	public Sprite itemSprite;

    public bool craftable;
    //public bool requiresResearch
    public IngredientInfo[] ingredients;
}

[Serializable]
public class IngredientInfo //Because normal dictionaries no visible in inspector :(
{
    string name;
    int amount;
}
