using UnityEngine;
using System.Collections;

public class ExitCampTriggerer : MonoBehaviour {

	public GameObject exitMenu;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
//			Debug.Log ("Exit Camp");
			Time.timeScale = 0;
			exitMenu.SetActive (true);
		}
	}

	public void CancelExit () {
		Time.timeScale = 1;
		exitMenu.SetActive (false);
	}
}
