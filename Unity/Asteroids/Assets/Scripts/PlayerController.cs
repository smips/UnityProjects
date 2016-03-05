using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	private bool thrustActive;

	public float thrustForce;
	[Header("Stabilizer")]
	public float brakingLinearDrag;
	public float brakingAngularDrag;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		thrustActive = false;
	}

	void Update(){
		if(Input.GetButton("X")){
			rb.drag = brakingLinearDrag;
			rb.angularDrag = brakingAngularDrag;
		} else {
			rb.drag = 0;
			rb.angularDrag = 0;
		}
		thrustActive = Input.GetButton ("A");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		if (rb.angularVelocity < 180) {
			rb.AddTorque (-horizontal);
		}

		if (thrustActive) {
			Debug.Log (transform.rotation.eulerAngles.z);
			Vector2 direction = new Vector2 (Mathf.Acos (transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Asin (transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
			rb.AddForce (direction * thrustForce);
		}

	}
}
