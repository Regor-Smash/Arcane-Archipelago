using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadZoneSelect : MonoBehaviour {

//	Transform charParent;
	GameObject currentCharImage;
	GameObject charButton;
	ExitCampMenuManager exitMenuMang;

//	public enum Zones
//	{
//		Squad, Research
//	}
//	public Zones zoneType;
	public int squadIndex;

	void Awake () {
		exitMenuMang = GetComponentInParent<ExitCampMenuManager> ();

//		if (zoneType == Zones.Squad) {
			//Set squad member
//			if (CharacterManager.squadPrefabs[squadIndex] != null) {
//				currentCharImage = Instantiate (charButton.transform.GetChild (0).gameObject);

//			}
//		}
	}

	public void ReadZone () {
		if (currentCharImage != null) {
			Destroy (currentCharImage);
			charButton.transform.Find("Image").GetComponent<Image> ().color = Color.white;
			charButton.GetComponent<Button> ().interactable = true;
			charButton = null;
		} else {
			exitMenuMang.currentSquadIndex = squadIndex;
			exitMenuMang.currentHighlight.transform.SetParent (gameObject.transform, false);
		}
	}

	public void CharToSquad (GameObject character) {
		charButton = character;

		currentCharImage = Instantiate (charButton.transform.GetChild (0).gameObject);
		currentCharImage.transform.SetParent (gameObject.transform, false);

		charButton.GetComponent<Button> ().interactable = false;
		charButton.transform.GetChild(0).GetComponent<Image> ().color = new Color (1, 1, 1, 0.1f);

//		Debug.Log ("Setting "+ currentCharImage.GetComponent<StringHolder>().text + " to slot #" + squadIndex.ToString ());

//		if (zoneType == Zones.Squad) {
			//Set squad member
			CharacterManager.squadPrefabs[squadIndex] = (GameObject) Resources.Load("Characters/" + currentCharImage.GetComponent<StringHolder>().text);
//		} else if (zoneType == Zones.Research) {
			//Start research
//		}
	}
}
