using UnityEngine;
using System.Collections;

public class SpawnResource : MonoBehaviour {

	public GameObject resourcePrefab;
	GameObject resource;

	void Start () {
		resource = (GameObject) Instantiate (resourcePrefab, Vector3.zero, Quaternion.identity);
		resource.transform.SetParent (gameObject.transform, false);
	}
}
