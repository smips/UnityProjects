using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using UnityEngine.UI;



public class NumberWizard : MonoBehaviour {
	int entered_min;
	int entered_max;
	int max;
	int min;
	int guess;
	public int maxGuesses = 10;
	
	public Text text;
	
	
	string current_input;
	
	bool init;
	bool init_min;
	bool init_max;
	// Use this for initialization
	void Start () {
		init = false;		
		init_min = false;		
		init_max = false;		
		current_input = "";
		min = 1;
		max = 1000;
		guess = Random.Range (min,max + 1);
		
		text.text = "Is this your number?\n" + guess.ToString ();
		//print ("Enter your minimum guess value.");		
	}
	
	void StartGame(){

		min = 1;
		max = 1000;
		
				
		//print ("========================");
		//print ("Welcome to Number Wizard");
		//print ("Secretly pick a number in your head...");
		
		//print ("This highest number you can pick is " + max);
		//print ("The lowest number you can pick is " + min);
		
		//NextGuess();
		
		//print ("Is the number higher or lower than " + guess + "?");
		//print ("Up arrow for higher, down arrow for lower, return for equal.");	

		max = max + 1;	
	}
	
	// Update is called once per frame
	void Update () {
		if (init){
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				GuessHigher();
			} else if (Input.GetKeyDown(KeyCode.DownArrow)){
				GuessLower();			
			}
		} else {
			var keys = Enum.GetValues (typeof(KeyCode));
			foreach(KeyCode k in keys){
				if (Input.GetKeyDown(k) && !Input.GetKeyDown(KeyCode.Return)){
					string temp = k.ToString ();
					temp = temp.Substring (temp.Length -1, 1);					
					current_input = current_input + temp;
				}
			}			
			
			if (Input.anyKeyDown && Input.GetKeyDown(KeyCode.Return)){
				if(!init_min){
					init_min = true;
					entered_min = Convert.ToInt16(current_input);
					current_input = "";
					//print ("You entered: " + entered_min);
					//print ("Enter your maximum guess value.");
				} else if (!init_max){
					init_max = true;
					init = true;
					entered_max = Convert.ToInt16(current_input);
					current_input = "";
					//print ("You entered: " + entered_max);
					StartGame();
				}			
			}
		}		
	}
	
	public void GuessHigher(){
			min = Mathf.Min(1000, guess + 1);
			NextGuess();
	}
	
	public void GuessLower(){
		max = Mathf.Max (1, guess - 1);
		NextGuess();		
	}
	
	void NextGuess(){
		guess = (min + max) / 2;
		guess = Random.Range(min,max);
		text.text = "Is this your number?\n" + guess.ToString ();
		maxGuesses = maxGuesses - 1;
		if(maxGuesses <= 0){
			Application.LoadLevel("Win");
		}
		//print ("Higher or lower than " + guess);
		//print ("Up arrow for higher, down arrow for lower, return for equal.");	
	}
}
