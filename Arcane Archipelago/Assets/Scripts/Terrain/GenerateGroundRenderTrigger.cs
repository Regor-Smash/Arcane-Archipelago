using UnityEngine;
using System.Collections;

public class GenerateGroundRenderTrigger : MonoBehaviour {

	void OnWillRenderObject () {
		GetComponentInParent<GenerateGround> ().GenerateNewGround ();
		this.enabled = false;
	}
}
