using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour {

	public float maxHealth = 300;
	public float currentHealth;
	public GameObject projectile;
	public float projectileSpeed;
	public float fireRate;
	public int score = 1250;
	public AudioClip deathSound;

	void Start() {
		currentHealth = maxHealth;
	}

	void Update(){
		float probability = Time.deltaTime * fireRate;
		if (Random.value < probability) {
			Invoke ("Fire", (fireRate) * Time.deltaTime + Random.Range(1,20) * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Projectile missle = other.GetComponent<Projectile> ();
		TakeDamage (missle.GetDamage());
		missle.Hit ();
	}

	void TakeDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Fire(){
		GameObject laser = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D> ().velocity = Vector3.down * Time.deltaTime * projectileSpeed;
	}

	void Death(){
		AudioSource.PlayClipAtPoint (deathSound, this.transform.position, 0.9f);
		Destroy (gameObject);
		GameObject.Find ("Score").GetComponent<ScoreKeeper> ().Score (score);
	}

}