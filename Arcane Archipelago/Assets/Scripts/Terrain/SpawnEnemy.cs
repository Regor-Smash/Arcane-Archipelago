using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public string[] possibleEnemies;
	string enemyName;
//	GameObject enemy;

	void Start () {
		enemyName = "Enemies/" + possibleEnemies [Random.Range (0, possibleEnemies.Length)];
		/*enemy = (GameObject) */Instantiate (Resources.Load (enemyName), gameObject.transform.position, Quaternion.identity);
	}
}
