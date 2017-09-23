using UnityEngine;
using System.Collections;

public class GenerateUnderground : MonoBehaviour {

	public Vector3 generateOffset;

	GameObject newUnderground;
	bool hasGeneratedNew = false;

	void OnWillRenderObject () {
		if (!hasGeneratedNew) {
			newUnderground = (GameObject) Instantiate (gameObject, transform.transform.localPosition + generateOffset, Quaternion.identity);
			newUnderground.transform.SetParent (transform.parent, false);
			hasGeneratedNew = true;
		}
	}
}
