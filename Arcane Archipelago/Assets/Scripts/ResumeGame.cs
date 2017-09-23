using UnityEngine;
using System.Collections;

public class ResumeGame : MonoBehaviour {

	public void Resume () {
		GameObject.FindGameObjectWithTag ("Manager").GetComponent <MenuManager> ().UnpauseGame ();
	}
}
