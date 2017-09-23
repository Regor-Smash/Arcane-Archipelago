using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour {

	static EffectManager effectMang;
	public static EffectManager GetEffectMang () {
		return effectMang;
	}

	public GameObject invItemEffectRef;
	GameObject invItemEffect;
	public Transform invEffectParent;

	void Awake () {
		if (effectMang == null) {
			effectMang = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else if (effectMang != this) {
			Debug.Log ("*Effect Manager dies*");
			Destroy (gameObject);
		} else if (effectMang == this) {
			Debug.Log ("*Effect Manager lives*");
		}
	}

	public void AddInvItemEffect (Sprite itemSprite, int itemAmount) {
		invItemEffect = (GameObject)Instantiate (invItemEffectRef);
		invItemEffect.transform.SetParent (invEffectParent, false);
		invItemEffect.GetComponentInChildren<Image>().sprite = itemSprite;
		invItemEffect.GetComponentInChildren<Text> ().text = "+ " + itemAmount.ToString ();
		Destroy (invItemEffect, 2.0f);
	}
}
