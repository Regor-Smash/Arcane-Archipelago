using UnityEngine;

public class HarvestResource : MonoBehaviour {

	public enum ToolTypes { None, Axe, Pickaxe}
	public ToolTypes requiredTool;

	SpriteRenderer sprite;
	public Color harvestHighlight;

	public enum Resources { Raw_Wood, Raw_Stone, Rubble, Large_Leaves}
	public Resources[] resourceType;
	public int[] harvestAmount;
	int actualAmount;

	public enum RareResource { Mystic_Bark, Purple_Rock}
	public RareResource rareResourceType;
	public int rarity;

	Collider2D thing;

	public void Start () {
		sprite = GetComponentInChildren<SpriteRenderer> ();
		if (resourceType.Length != harvestAmount.Length) {
			Debug.LogError ("Resource type and amount do not match on " + gameObject.name);
			return;
		}
	}

	void Update () {
		if (Input.GetButtonDown ("Interact") && thing != null) {
			for (int a = 0; a < resourceType.Length; a++) {
				actualAmount = (int) (harvestAmount [a] * Random.Range (0.5f, 2.5f));
				if (actualAmount != 0) {
					InventoryManager.AddInvItem (resourceType[a].ToString (), actualAmount);
//					Debug.Log ("Added " + actualAmount + " " + resourceType [a].ToString ());
				}
			}

			int x = Random.Range (0, rarity + 1);
			if (x == rarity) {
				InventoryManager.AddInvItem (rareResourceType.ToString (), 1);
			}

			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
//		Debug.Log (gameObject.name +" is colliding with a "+ col.tag);
		if (col.CompareTag ("Player")) {
			sprite.color = harvestHighlight;

			thing = col;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			sprite.color = Color.white;

			thing = null;
		}
	}
}
