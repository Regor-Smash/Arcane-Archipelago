using UnityEngine;
using System.Collections;

public class ReadSaveSlot : MonoBehaviour {

	public void OnClicked () {
//		Debug.Log ("Save slot selected");
		GetComponentInParent <ContinueGame> ().currentSlot = gameObject;
	}
}
