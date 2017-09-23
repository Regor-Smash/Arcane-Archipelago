using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour {

	public static bool isDialogue;
	public bool calibrating;

	public GameObject tip;
	public GameObject[] dialogue;
	int a = 1;

	void Awake () {
		if (SaveManager.currentData.dialoguesRead.Contains(gameObject.name)) {
			isDialogue = false;
			gameObject.SetActive (false);
		} else {
			isDialogue = true;
		}
		dialogue [0].transform.parent.gameObject.SetActive (true);
		dialogue [0].SetActive (true);
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && !calibrating) {
			if (a != 0) {
				dialogue [a - 1].transform.parent.gameObject.SetActive (false);
				dialogue [a - 1].SetActive (false);
			}
			if (a < dialogue.Length) {
				dialogue [a].transform.parent.gameObject.SetActive (true);
				dialogue [a].SetActive (true);
				a++;
			} else {
				isDialogue = false;
				SaveManager.currentData.dialoguesRead.Add (gameObject.name);

				if (tip != null) {
					tip.SetActive (true);
				}
			}
		}
	}
}
