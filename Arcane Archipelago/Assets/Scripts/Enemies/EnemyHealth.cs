using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int totalHealth;
	[HideInInspector]public float currentHealth;

	public enum LootDrops {
		None, Magipine_Tail}
	public LootDrops[] drops;
	public int[] dropAmount;
	int actualAmount;

	public enum RareLootDrops {
		None, Magipine_Quill}
	public RareLootDrops rareDrop;
	public int rarity;

	void Start () {
		currentHealth = totalHealth;

		if (drops.Length != dropAmount.Length) {
			Debug.LogError ("Resource type and amount do not match on " + gameObject.name);
			return;
		}
	}

	void Update () {
		if (currentHealth <= 0) {
			//Drop loot
			for (int a = 0; a < drops.Length; a++) {
				actualAmount = (int) (dropAmount [a] * Random.Range (0.5f, 1.5f));
				InventoryManager.AddInvItem (drops[a].ToString (), actualAmount);
//				Debug.Log ("Added " + actualAmount + " " + resourceType [a].ToString ());
			}

			int x = Random.Range (0, rarity + 1);
			if (x == rarity) {
				InventoryManager.AddInvItem (rareDrop.ToString (), 1);
			}

			//Die
			Destroy (gameObject);
		}
	}

	void TakeDamage (float damage) {
		currentHealth -= damage;
	}
}
