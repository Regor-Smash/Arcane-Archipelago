using UnityEngine;
using System.Collections;

public class HillAssist : MonoBehaviour {

	Vector2 upperOrigin;	//Set origins to outside of character collider
	RaycastHit2D upperHit;
	public Vector2 upperOffset;

	Vector2 lowerOrigin;	//Set origins to outside of character collider
	RaycastHit2D lowerHit;
	public Vector2 lowerOffset;

	public float assistDist;
	public float assist;

	Movement charMove;
	Rigidbody2D rb;

	public bool testing;
	GameObject upperDot;
	GameObject lowerDot;

	void Start () {
		charMove = GetComponent <Movement> ();
		rb = GetComponent <Rigidbody2D> ();

		if (testing) {
			upperDot = (GameObject) Instantiate (Resources.Load ("Testing/Test Dot"));
			lowerDot = (GameObject) Instantiate (Resources.Load ("Testing/Test Dot"));
		}
	}

	void Update () {
		if (charMove.isFacingRight && GetComponentInParent<PersonalManager>().isActiveChar) {
			upperOrigin = (Vector2) transform.position + upperOffset;
			lowerOrigin = (Vector2) transform.position + lowerOffset;

			if (testing) {
				upperDot.transform.position = new Ray2D (upperOrigin, transform.right).GetPoint (assistDist);
				lowerDot.transform.position = new Ray2D (lowerOrigin, transform.right).GetPoint (assistDist);
			}

			if (!Physics2D.Raycast (upperOrigin, transform.right, assistDist) && Physics2D.Raycast (lowerOrigin, transform.right, assistDist) && Input.GetButton ("Horizontal")) {
				rb.AddForce (new Vector2 (0, assist * rb.mass), ForceMode2D.Force);

				if (testing) {
					Debug.Log ("Assisted! Movement: Right");
				}
			}
		} else if (!charMove.isFacingRight && GetComponentInParent<PersonalManager>().isActiveChar) {
			upperOrigin = (Vector2) transform.position + new Vector2 (-upperOffset.x, upperOffset.y);
			lowerOrigin = (Vector2) transform.position + new Vector2 (-lowerOffset.x, lowerOffset.y);

			if (testing) {
				upperDot.transform.position = new Ray2D (upperOrigin, -transform.right).GetPoint (assistDist);
				lowerDot.transform.position = new Ray2D (lowerOrigin, -transform.right).GetPoint (assistDist);
			}

			if (!Physics2D.Raycast (upperOrigin, -transform.right, assistDist) && Physics2D.Raycast (lowerOrigin, -transform.right, assistDist) && Input.GetButton ("Horizontal")) {
				rb.AddForce (new Vector2 (0, assist * rb.mass), ForceMode2D.Force);

				if (testing) {
					Debug.Log ("Assisted! Movement: Left");
				}
			}
		}
	}
}
