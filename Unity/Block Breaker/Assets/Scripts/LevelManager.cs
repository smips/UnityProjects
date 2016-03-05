using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private static int lives;
	private Text livesText;
	private Ball ball;

	void Start(){
		OnLevelWasLoaded ();
	}
	
	
	public void StartGame(){
		lives = 3;
		LoadLevel("Level_01");
	}

	public void LoadLevel(string name){
		Brick.breakableCount = 0;
		Debug.Log ("Loading : " + name);
		Application.LoadLevel(name);

	}
	
	void OnLevelWasLoaded(){
	Debug.Log("Level Loaded");
		if(lives == 0){
		lives = 3;
	}
		if(Application.loadedLevelName != "Start" && Application.loadedLevelName != "Lose" && Application.loadedLevelName != "Win") {
			livesText = GameObject.Find ("LivesText").GetComponent<Text>();
			ball = GameObject.Find("Ball").GetComponent<Ball>();		
			updateLivesText();
		}
	}

	public void LoadNextLevel ()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
	
	public void LoseLife(){
		lives--;
		updateLivesText();
		ball.Restart();
		if(lives <= 0) {
			Application.LoadLevel("Lose");
		}
	}
	
	private void updateLivesText(){
		livesText.text = "Lives Remaining: " + lives;
	}

}
