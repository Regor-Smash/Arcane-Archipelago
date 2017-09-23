using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndArea : MonoBehaviour {

	public int unlockedIndex;
	public bool toCamp;
	public string loadScene;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (toCamp) {
				if (SaveManager.currentData.unlockedAreas == unlockedIndex - 1) {
					SaveManager.currentData.unlockedAreas = unlockedIndex;
				}

				SceneManager.LoadScene ("Scenes/Base Camp");
			} else {
				SceneManager.LoadScene ("Scenes/" + loadScene);
			}
		}
	}
}
