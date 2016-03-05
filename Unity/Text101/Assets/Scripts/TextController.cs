using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	private enum States{cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, 
						corridor_0, stairs_0, closet_door, stairs_1, corridor_1, in_closet, 
						stairs_2, corridor_2, corridor_3, courtyard, floor};
	private States myState;
	public Text text;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.cell)		{cell ();} 
		else if (myState == States.sheets_0)	{sheets_0 ();}
		else if (myState == States.lock_0)		{lock_0 ();}
		else if (myState == States.mirror)		{mirror ();}
		else if (myState == States.cell_mirror)	{cell_mirror ();}
		else if (myState == States.sheets_1)	{sheets_1 ();}
		else if (myState == States.lock_1)		{lock_1 ();}
		else if (myState == States.corridor_0)	{corridor_0 ();}
		/*
		else if (myState == States.corridor_1){corridor_1 ();}
		else if (myState == States.corridor_2){corridor_2 ();}
		else if (myState == States.corridor_3){corridor_3 ();}
		else if (myState == States.stairs_0){stairs_0 ();}
		else if (myState == States.stairs_1){stairs_1 ();}
		else if (myState == States.stairs_2){stairs_2 ();}
		else if (myState == States.floor){floor ();}
		else if (myState == States.closet_door){closet_door();}
		else if (myState == States.in_closet){in_closet ();}
		else if (myState == States.courtyard){courtyard ();}
		*/
	}
	
	void cell(){
		text.text = "You are in a prison cell against your will. You need to " +
			"escape. The air is damp and musty. You see a bed with " +
				"dirty sheets, a foggy mirror on the wall, and a cell door.\n\n" + 
				"S to inspect the sheets\nPress M to inspect the mirror\nPress " +
				"L to inspect the door.";
		if(Input.GetKeyDown(KeyCode.S))	{myState = States.sheets_0;}
		if(Input.GetKeyDown(KeyCode.M))	{myState = States.mirror;}
		if(Input.GetKeyDown(KeyCode.L))	{myState = States.lock_0;}
	}
	
	void sheets_0(){
		text.text = "These sheets are disgusting. You can't believe " +
					"you're supposed to sleep in these.\n\nR to return.";
		if(Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void mirror(){
		text.text = "The mirror is so dirty you cannot even see your " +
					"reflection. You find a bobby pin wedged between the " +
					"mirror and the wall\n\nT to take the bobby pin\n R to " +
					"return.";
		if(Input.GetKeyDown(KeyCode.T))	{myState = States.cell_mirror;}
		if(Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void lock_0(){
		text.text = "It's a rusty. iron cell door. You try to slide " +
					"it open, but it is locked. You think you can reach " +
					"the keyhole through the bars.\n\nR to return.";
		if(Input.GetKeyDown(KeyCode.R)){myState = States.cell;}
	}
	
	void cell_mirror(){
		text.text = "You are in a prison cell against your will. You need to " +
					"escape. The air is damp and musty. You see a bed with " +
					"dirty sheets, a foggy mirror on the wall, and a cell door.\n\n" + 
					"S to inspect the sheets\nPress " +
					"L to inspect the door.";
		if(Input.GetKeyDown(KeyCode.S))	{myState = States.sheets_1;}
		if(Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}
	}
	
	void sheets_1(){
		text.text = "These sheets are disgusting. You can't believe " +
			"you're supposed to sleep in these.\n\nR to return.";
		if(Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void lock_1(){
		text.text = "It's a rusty. iron cell door. You try to slide " +
					"it open, but it is locked. You think you can reach " +
					"the keyhole through the bars.\n\nO to pick the lock " +
					"and open the door\nR to return.";
		if(Input.GetKeyDown(KeyCode.O))	{myState = States.corridor_0;}
		if(Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void corridor_0(){
		text.text = "You pick the lock and slide the door open. You step " +
					"out of the cell into a dimly lit hallway.You hear a " +
					"voices echoing down from the top of a set of stairs " +
					"and a closet door beside your cell.\n\nPress S to go " +
					"up the stairs\nPress F to search the Floor\nPress C " +
					"to inspect the closet.";
		if(Input.GetKeyDown(KeyCode.S))	{myState = States.stairs_0;}
		if(Input.GetKeyDown(KeyCode.F))	{myState = States.floor;}
		if(Input.GetKeyDown(KeyCode.C))	{myState = States.closet_door;}
		
	}
}
