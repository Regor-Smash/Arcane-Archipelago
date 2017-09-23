using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadInvSlot : MonoBehaviour {

	public enum SlotTypes {
		Inv_Item, Craft_Recipe
	}
	public SlotTypes slotType;

	[HideInInspector] public string itemName;

	public void ReadSlot () {
//		Debug.Log ("Inv slot selected");
		if (slotType == SlotTypes.Inv_Item) {
			GetComponentInParent <InvLister> ().ChangeInvItem (itemName);
		} else if (slotType == SlotTypes.Craft_Recipe) {
			GetComponentInParent <Crafter> ().ChangeRecipe (itemName);
		}
	}
}
