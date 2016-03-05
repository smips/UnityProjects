using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float movementSpeed;
	public GameObject projectile;
	public float projectileSpeed;
	public float fireRate;
	public float maxHealth = 1000;
	public float currentHealth;

	private float lastFire = 0;
	float xMin = -5;
	float xMax = 5;

	void Start(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distance));
		xMin = leftmost.x + this.transform.localScale.x/2;
		xMax = rightmost.x - this.transform.localScale.x/2;
		currentHealth = maxHealth;
	}

	void OnTriggerEnter2D(Collider2D other){
		Projectile missle = other.GetComponent<Projectile> ();
		//if (missle.CompareTag("EnemyProjectile")) {			
			TakeDamage (missle.GetDamage());
			missle.Hit ();
		//} else {
		//	Debug.Log ("Other collision.");
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * movementSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		}
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if(Input.GetKeyDown(KeyCode.Space)){
			if ((Time.time - lastFire) >= fireRate) {
				InvokeRepeating ("Fire", 0.00001f, fireRate);
				Debug.Log ("Immediate");
			} else {
				InvokeRepeating ("Fire", Time.time - lastFire, fireRate);
				Debug.Log ("Delayed");
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
	}

	void Fire(){
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = Vector3.up * Time.deltaTime * projectileSpeed;
		lastFire = Time.time;
	}

	void TakeDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Death(){
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().LoadLevel ("Win Screen");
		Destroy (gameObject);
	}
}
