using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public static bool isPaused;
	public GameObject pMenuPrefab;
	GameObject pMenu;

	public GameObject invMenuPrefab;
	GameObject invMenu;

	void Awake () {
		pMenu = (GameObject) Instantiate (pMenuPrefab);
		pMenu.SetActive (false);

		invMenu = (GameObject) Instantiate (invMenuPrefab);
		invMenu.SetActive (false);
	}

	void Update () {
		if (Input.GetButtonDown ("Cancel") && isPaused) {
			UnpauseGame ();
		} else if (Input.GetButtonDown ("Cancel") && !isPaused) {
			PauseGame ();
		}

		if (Input.GetButtonDown ("Inventory")) {
			invMenu.SetActive (!invMenu.activeSelf);
		}
	}

	public void PauseGame () {
		isPaused = true;
		Time.timeScale = 0;
		pMenu.SetActive (true);
	}

	public void UnpauseGame () {
		isPaused = false;
		Time.timeScale = 1;
		pMenu.SetActive (false);
	}
}
