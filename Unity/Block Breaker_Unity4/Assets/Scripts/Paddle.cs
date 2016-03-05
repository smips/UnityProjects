using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		} else {
			AutoPlay ();
		}
		
	}
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
		float mousePosInBlocks;
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
		
		float zRotation = 0;
		Debug.Log (zRotation);
		if(Input.GetMouseButton(1)){		
			zRotation = 1f;
		} else if (Input.GetMouseButton(0)){	
			zRotation = -1f;
		}
		else {
			if(transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z >= 180){
				zRotation = 1f;
			} else if (transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180){
				zRotation = -1f;
			}
		}
		this.transform.Rotate(0f, 0f, zRotation);
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
		Vector3 ballPos;
		ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
	
}
