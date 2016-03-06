using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	private SpriteRenderer spriteRenderer;
	private bool thrustActive;
    [Header("Movement")]
	public float thrustForce;
    [Header("Turning")]
    public float maxAngularVelocity;
    public float torqueScaler;
    [Header("Stabilizer")]
    public float defaultLinearDrag;
	public float brakingLinearDrag;
    public float defaultAngularDrag;
	public float brakingAngularDrag;
	[Header("Sprites")]
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		thrustActive = false;
	}

	void Update(){
		if(Input.GetButton("X")){
			rb.drag = brakingLinearDrag;
			rb.angularDrag = brakingAngularDrag;
		} else {
			rb.drag = defaultLinearDrag;
			rb.angularDrag = defaultAngularDrag;
		}
		thrustActive = Input.GetButton ("A");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
        float currentAngularVelocity = rb.angularVelocity;
		if ((currentAngularVelocity <= maxAngularVelocity) && (currentAngularVelocity >= -maxAngularVelocity )) {
			rb.AddTorque (-horizontal * torqueScaler);
		} else{
            if (currentAngularVelocity > 0){
                rb.angularVelocity = maxAngularVelocity;
            }   else{
                rb.angularVelocity = -maxAngularVelocity;
            }
        }

		if (horizontal > 0.1) {
			if (thrustActive) {
				spriteRenderer.sprite = sprites [5];
			} else {
				spriteRenderer.sprite = sprites [4];
			}
		} else if (horizontal < -0.1) {
			if (thrustActive) {
				spriteRenderer.sprite = sprites [3];
			} else {
				spriteRenderer.sprite = sprites [2];
			}
		} else {
			if (thrustActive) {
				spriteRenderer.sprite = sprites [1];
			} else {
				spriteRenderer.sprite = sprites [0];
			}
		}

		if (thrustActive) {
            float currentAngle = (this.transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
			Vector2 direction = new Vector2 (Mathf.Cos (currentAngle), Mathf.Sin (currentAngle));
			rb.AddForce (direction * thrustForce);
		}

	}
}
