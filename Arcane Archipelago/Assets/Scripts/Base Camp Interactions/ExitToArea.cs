using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToArea : MonoBehaviour
{
	[HideInInspector] public string sceneName;

	public void ChangeScene ()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene("Scenes/" + sceneName);
            Time.timeScale = 1;
        }
	}
}
