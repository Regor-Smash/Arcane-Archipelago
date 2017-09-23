using UnityEngine;
using UnityEngine.UI;

public class DeleteSave : MonoBehaviour {

	public ContinueGame contGame;

	string defaultQ;
	string newQ;
	string saveName;

	void Awake () {
		defaultQ = GetComponent<Text> ().text;
	}
	void OnEnable () {
		saveName = contGame.currentSlot.GetComponentInChildren<Text> ().text;
		if (contGame.currentSlot != null) {
			newQ = defaultQ + saveName;
			GetComponent<Text> ().text = newQ;
		} else if (contGame.currentSlot == null){
			GetComponent<Text> ().text = "No Save Selected";
		}
	}

	public void ReallyDeleteTheSave () {
		if (contGame.currentSlot != null) {
			SaveManager.DeleteSave (saveName);
		}
	}
}
