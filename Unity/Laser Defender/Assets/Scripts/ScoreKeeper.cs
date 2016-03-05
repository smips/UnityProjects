using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

public class ScoreKeeper : MonoBehaviour {
	public static int score;
	private Text scoreText;

	void Start(){
		scoreText = GameObject.Find("Score").GetComponent<Text>();
		Reset ();
		UpdateText ();
	}

	public void Score(int points){
		score += points;
		UpdateText ();
	}

	public static void Reset(){
		score = 0;
		//UpdateText ();
	}

	void UpdateText(){
		scoreText.text = "Score: " + score;
	}
}