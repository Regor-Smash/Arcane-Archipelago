using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Crafter : MonoBehaviour {

	[HideInInspector] public GameObject currentSlot;
	public GameObject recipeSlot;

	GameObject[] recipeList;
	string[] allRecipes;

	public Text title;
	public Text amount;
	public Image itemSprite;

	void OnEnable () {
		allRecipes = SaveManager.currentData.unlockedCraftingRecipes.ToArray();
		System.Array.Resize (ref recipeList, allRecipes.Length);

		for (int a = 0; a < allRecipes.Length; a++){
			//Make an in-game list of all current inventory items
			//by spawning a button for each item
			recipeList [a] = Instantiate (recipeSlot);
			recipeList [a].GetComponentInChildren<Text> ().text = "\t" + InventoryManager.LoadItemData (allRecipes [a]).displayName + //name
				"\t\t\t x" + InventoryManager.invList[allRecipes [a]].ToString ();//amount
			recipeList [a].GetComponentInChildren<ReadInvSlot> ().itemName = allRecipes [a];
			recipeList [a].transform.SetParent (transform, false);
			recipeList [a].GetComponent <RectTransform> ().anchoredPosition = new Vector3 (0, -30 * a - 20, 0);
			GetComponent <RectTransform> ().sizeDelta = new Vector2 (0, 30 * (a + 1) + 10);
		}
	}

	public void ChangeRecipe (string recName) {
		title.text = InventoryManager.LoadItemData (recName).displayName;
		amount.text = "Crafted Amount: " + InventoryManager.LoadItemData (recName);
		itemSprite.sprite = InventoryManager.LoadItemData (recName).itemSprite;
	}

	void OnDisable() {
		foreach (GameObject go in recipeList) {
			Destroy (go);
		}
	}
}
