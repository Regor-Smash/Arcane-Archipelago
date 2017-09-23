using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour {

	public void ChangeScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
		Time.timeScale = 1;
	}
}
