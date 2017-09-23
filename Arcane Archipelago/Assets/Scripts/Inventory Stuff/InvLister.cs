using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class InvLister : MonoBehaviour {

	[HideInInspector] public GameObject currentSlot;
	public GameObject invSlot;

	GameObject[] itemList;
	string[] allItems;

	public Text title;
	public Text amount;
	public Image itemSprite;

	void OnEnable () {
		allItems = (string[]) InventoryManager.invList.Keys.ToArray();
		System.Array.Resize (ref itemList, allItems.Length);

		for (int a = 0; a < allItems.Length; a++){
			//Make an in-game list of all current inventory items
			//by spawning a button for each item
			itemList [a] = Instantiate (invSlot);
			itemList [a].GetComponentInChildren<Text> ().text = "\t" + InventoryManager.LoadItemData (allItems [a]).displayName + //name
				"\t\t\t x" + InventoryManager.invList[allItems [a]].ToString ();//amount
			itemList [a].GetComponentInChildren<ReadInvSlot> ().itemName = allItems [a];
			itemList [a].transform.SetParent (transform, false);
			itemList [a].GetComponent <RectTransform> ().anchoredPosition = new Vector3 (0, -30 * a - 20, 0);
			GetComponent <RectTransform> ().sizeDelta = new Vector2 (0, 30 * (a + 1) + 10);
		}
	}

	public void ChangeInvItem (string itemName) {
		title.text = InventoryManager.LoadItemData (itemName).displayName;
		amount.text = "Amount: " + InventoryManager.invList[itemName];
		itemSprite.sprite = InventoryManager.LoadItemData (itemName).itemSprite;
	}

	void OnDisable() {
		foreach (GameObject go in itemList) {
			Destroy (go);
		}
	}
}
