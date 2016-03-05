using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;



public class NumberWizard : MonoBehaviour {
	int entered_min;
	int entered_max;
	int max;
	int min;
	int guess;
	
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
		print ("Enter your minimum guess value.");		
	}
	
	void StartGame(){

		min = entered_min;
		max = entered_max;
				
		print ("========================");
		print ("Welcome to Number Wizard");
		print ("Secretly pick a number in your head...");
		
		print ("This highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
		NextGuess();
		
		print ("Is the number higher or lower than " + guess + "?");
		print ("Up arrow for higher, down arrow for lower, return for equal.");	

		max = max + 1;	
	}
	
	// Update is called once per frame
	void Update () {
		if (init){
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				min = Mathf.Min(1000, guess + 1);
				NextGuess();
			} else if (Input.GetKeyDown(KeyCode.DownArrow)){
				max = Mathf.Max (1, guess - 1);
				NextGuess();
			} else if (Input.GetKeyDown(KeyCode.Return)){
				print ("I won!");
				StartGame();
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
					print ("You entered: " + entered_min);
					print ("Enter your maximum guess value.");
				} else if (!init_max){
					init_max = true;
					init = true;
					entered_max = Convert.ToInt16(current_input);
					current_input = "";
					print ("You entered: " + entered_max);
					StartGame();
				}			
			}
		}		
	}
	
	void NextGuess(){
		//guess = (min + max) / 2;
		guess = Random.Range(min,max);
		print ("Higher or lower than " + guess);
		print ("Up arrow for higher, down arrow for lower, return for equal.");	
	}
}
