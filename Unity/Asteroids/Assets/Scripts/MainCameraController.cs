using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    private PlayerController player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        transform.position = new Vector3(playerX, playerY, transform.position.z);
	}
}
