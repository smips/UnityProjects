using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;
	private int maxHits;
	private int timesHit;
	private bool isBreakable;
	
	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;
	
	public static int breakableCount = 0;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		timesHit = 0;
		maxHits = hitSprites.Length + 1;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		if(isBreakable){
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionExit2D(Collision2D collider) {
		AudioSource.PlayClipAtPoint(crack, this.transform.position, 0.1f);
		bool isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			HandleHits ();
		}
	}
	
	void HandleHits(){	
		timesHit++;
		if (timesHit >= maxHits){
			breakableCount--;
			Object.Destroy(gameObject);			
			levelManager.BrickDestroyed();
			GenerateSmoke ();

		} else {
			LoadSprites();
		}
	}
	
	void GenerateSmoke(){
		GameObject smokeInstance = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokeInstance.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite is missing.");
		}
	}
	
	void SimulateWin ()
	{
		levelManager.LoadNextLevel();
	}
}
