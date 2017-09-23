using UnityEngine;
using System.Collections;

public class CampCharacterManager : MonoBehaviour {
	//Goes on player camera

//	static GameObject activeChar;
//	int activeCharIndex;

	GameObject player;
//	public static GameObject[] squadPrefabs;
//	public Vector3[] squadOffsets;
//	int totalChars;

	void Start () {
		SpawnPlayer ();
	}

//	void Update () {
//		if (Input.GetButtonDown ("Change Character") && !DialogueController.isDialogue) {
//			ChangeCharacter ();
//		}
//	}

	void SpawnPlayer () {
		if (player != null) {
			Destroy (player);
		}
		player = (GameObject) Instantiate(CharacterManager.squadPrefabs [0], Vector3.zero, Quaternion.identity);
//		Debug.Log ("Spawned '" + player.name + "'");

		transform.SetParent (player.transform, false);
		player.GetComponent <PersonalManager> ().CharacterChanged (player);
	}

//	void ChangeCharacter () {
//		if (!hasInitialized) {
//			hasInitialized = true;
//		}
//		activeCharIndex = activeCharIndex + (int)Input.GetAxis ("Change Character");
//		if (activeCharIndex > totalChars - 1) {
//			activeCharIndex = 0;
//		} else if (activeCharIndex < 0) {
//			activeCharIndex = totalChars - 1;
//		}
//
//		activeChar = squad [activeCharIndex];
//		transform.SetParent (activeChar.transform, false);
//		transform.localPosition = new Vector3 (0, 0, -1);
//
//		foreach (GameObject character in squad) {
//			character.GetComponent <PersonalManager> ().CharacterChanged (activeChar);
//		}
//	}
}
