using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitCampMenuManager : MonoBehaviour {

	[HideInInspector] public GameObject currentChar;
	[HideInInspector] public int currentSquadIndex;
	public GameObject[] squadSlots;

	public GameObject currentHighlight;
	public Transform highlightHolder;

	void OnEnable () {
		ResetMenu ();
	}

	void Update () {
		if (currentChar != null && currentSquadIndex != -1) {
			ChooseChar (currentSquadIndex, currentChar);

			ResetMenu ();
		}
	}

	void ResetMenu () {
		currentChar = null;
		currentSquadIndex = -1;
		currentHighlight.transform.SetParent (highlightHolder, false);
	}

	public void ChooseChar (int x, GameObject stuff) {
		squadSlots[x].GetComponent<ReadZoneSelect> ().CharToSquad (stuff);
	}
}
