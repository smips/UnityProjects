using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float width = 10;
	public float height = 5;
	public float movementSpeed;
	public float currentSpeed = 0;
	public float moveFrequency = 1.75f;
	public float moveMagnitude = 3f;
	public float spawnDelay = 0.5f;

	private float xMin;
	private float xMax;
	private bool moveLeft = true;


	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		SpawnUntilFull ();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distance));
		xMin = leftmost.x + width/2;
		xMax = rightmost.x - width/2;
	}

	void SpawnEnemies(){
		foreach (Transform child in transform) {
			GameObject enemyInstance = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemyInstance.transform.SetParent (child);
		}
	}

	void SpawnUntilFull(){
		Transform nextPosition = NextFreePosition ();
		if (nextPosition) {
			GameObject enemyInstance = Instantiate (enemyPrefab, nextPosition.position, Quaternion.identity) as GameObject;
			enemyInstance.transform.SetParent (nextPosition);
		} else {
			return;
		}
		Invoke ("SpawnUntilFull", spawnDelay);
	}

	Transform NextFreePosition(){
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount <= 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead(){
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}

	// Update is called once per frame
	void Update () {
		if (moveLeft) {
			transform.position += Vector3.left * movementSpeed * Time.deltaTime;
		} else { //Move right
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		}
		

		if (transform.position.x <= xMin) {
			moveLeft = false;
		} else if (transform.position.x >= xMax) {
			moveLeft = true;
		}

		transform.position += Vector3.up * Time.deltaTime * Mathf.Sin (Time.time * moveFrequency) * moveMagnitude;

		if (AllMembersDead ()) {
			SpawnUntilFull ();
		}
	}

}
