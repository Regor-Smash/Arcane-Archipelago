using UnityEngine;
using UnityEngine.UI;

public class ReadAreaSelect : MonoBehaviour {
	//Goes on button's text

	public string areaName;
	public int unlockIndex;

	void OnEnable () {
		if (SaveManager.currentData.unlockedAreas < unlockIndex) {
			GetComponentInParent<Button> ().interactable = false;
		} else {
			GetComponentInParent<Button> ().interactable = true;
		}
	}

	public void ReadArea () {
//		Debug.Log ("Area '"+ areaName +"' selected");
		GetComponentInParent<ExitToArea>().sceneName = areaName;
	}
}
