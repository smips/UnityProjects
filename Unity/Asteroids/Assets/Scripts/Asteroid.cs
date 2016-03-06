using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	[Header("Starting Rotation and Force")]
	public float minRotation;
	public float maxRotation;
	public float maxForce;
	[Header("On Destruction")]
	public GameObject[] Prefabs;
	public int[] quantity;
	public float explosionForce;

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		rb.angularVelocity = Random.Range (minRotation, maxRotation);
		rb.AddForce(new Vector2(Random.Range(0, maxForce), Random.Range(0, maxForce)));

	}

	void OnCollisionEnter2D(Collision2D collision){
		//Debug.Log ("Collided with " + collision.gameObject.name);
		if (collision.gameObject.name == "Player") {
			Die ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Die(){
		Vector2 finalPosition = this.transform.position;
		//this.GetComponent<PolygonCollider2D> ().isTrigger = true;
		Destroy (gameObject);
		for (int j = 0; j < Prefabs.Length; j++) {
			if (Prefabs[j] && quantity[j] > 0) {
				for (int i = 0; i < quantity[j]; i++) {
					//float spriteWidth = nextPrefab.GetComponent<SpriteRenderer> ().sprite.bounds.size.x / 2;
					//float spriteHeight = nextPrefab.GetComponent<SpriteRenderer> ().sprite.bounds.size.y / 2;
					//Vector2 spawnPoint = GetSpawnPoint (spriteWidth,spriteHeight, finalPosition);
					GameObject temp = Instantiate (Prefabs[j], finalPosition, Quaternion.identity) as GameObject;
					Vector2 forceDirection = new Vector2 (Random.Range (-1, 1), Random.Range (-1, 1));
					forceDirection.Normalize ();
					temp.GetComponent<Rigidbody2D> ().AddForce (forceDirection * explosionForce);
				}
			}
		}
	}

	Vector2 GetSpawnPoint(float xRange, float yRange, Vector2 origin){
		Vector2 spawnPoint = Vector2.zero;
		Collider2D[] hitColliders;

		do {
			float xPos = origin.x + Random.Range(-xRange, xRange);
			float yPos = origin.y + Random.Range(-yRange, yRange);
			spawnPoint = new Vector2(xPos, yPos);
			Vector2 pt1 = new Vector2(spawnPoint.x - xRange, spawnPoint.y + yRange);
			Vector2 pt2 = new Vector2(spawnPoint.x + xRange, spawnPoint.y - yRange);
			hitColliders = Physics2D.OverlapAreaAll(pt1, pt2);
			origin = spawnPoint;
		} while (hitColliders.Length > 0);

		return spawnPoint;
	}
}
