using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	private enum States{bedroom_0, door_0, fishtank_0, closet_0, closet_1, bedroom_1, door_1, fishtank_1,
						hallway_0, h_door_0_0, h_door_1_0, h_door_2_0, hatch_0, cliff_0, empty_room_0, 
						utility_closet_0, utility_closet_1, h_door_2_1, hallway_1, hatch_1, end,
						h_door_1_1, h_door_0_1, cliff_1, empty_room_1
	}
	
	public Text text;
	private States myState;
	
	// Use this for initialization
	void Start () {
		text.text = "Hello world!";
		myState = States.bedroom_0;
	}


	
	// Update is called once per frame
	void Update () {
		print (myState);
		if(myState == States.bedroom_0)			{bedroom_0();}
		if(myState == States.door_0)			{door_0();}
		if(myState == States.fishtank_0)		{fishtank_0();}
		if(myState == States.closet_0)			{closet_0();}
		if(myState == States.closet_1)			{closet_1();}
		if(myState == States.bedroom_1)			{bedroom_1();}
		if(myState == States.door_1)			{door_1();}
		if(myState == States.fishtank_1)		{fishtank_1();}
		if(myState == States.hallway_0)			{hallway_0();}
		if(myState == States.h_door_0_0)		{h_door_0_0();}
		if(myState == States.h_door_1_0)		{h_door_1_0();}
		if(myState == States.h_door_2_0)		{h_door_2_0();}
		if(myState == States.h_door_0_1)		{h_door_0_1();}
		if(myState == States.h_door_1_1)		{h_door_1_1();}
		if(myState == States.h_door_2_1)		{h_door_2_1();}
		if(myState == States.hatch_0)			{hatch_0();}
		if(myState == States.cliff_0)			{cliff_0();}
		if(myState == States.empty_room_0)		{empty_room_0();}
		if(myState == States.cliff_1)			{cliff_1();}
		if(myState == States.empty_room_1)		{empty_room_1();}
		if(myState == States.utility_closet_0)	{utility_closet_0();}
		if(myState == States.utility_closet_1)	{utility_closet_1();}
		if(myState == States.hallway_1)			{hallway_1();}
		if(myState == States.hatch_1)			{hatch_1();}
		if(myState == States.end)				{end();}
	}
	
	void bedroom_0(){
		text.text = "You wake up and find yourself in a messy bedroom with clothes and " +
					"books strewn about the floor. Nothing about the room feels familiar to you. " +
					"There is a closet overflowing with boxes and a door you hope leads out of " +
					"the room. There is a fishtank in the corner. " + 
					"\n\n" +
					"Press D to inspect the door\n" + 
					"Press F to inspect the fishtank\n" +
					"Press C to inspect the closet\n";
		if(Input.GetKeyDown(KeyCode.D))		{myState = States.door_0;}
		if(Input.GetKeyDown(KeyCode.F))		{myState = States.fishtank_0;}
		if(Input.GetKeyDown(KeyCode.C))		{myState = States.closet_0;}
	}

	void door_0 ()
	{
		text.text = "The door seems to be locked. You see a keyhole on the door knob." + 
					"\n\n" +
					"Press R to return to the bedroom\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.bedroom_0;}
	}

	void fishtank_0 ()
	{
		text.text = "It seems like no one has been around to care for the fish in a long " +
					"time. The water is murky, but peering through it you can see what looks " +
					"like a key." + 
					"\n\n" +
					"Press T take the key\n" + 
					"Press R to return to the bedroom\n";
		if(Input.GetKeyDown(KeyCode.T))		{myState = States.fishtank_1;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.bedroom_0;}
	}

	void closet_0 ()
	{
		text.text = "Boxes that had been stacked in the closet seem to have fallen " +
					"over, spilling thier contents everywhere. Clothing, photos of people " +
					"you do not recognize, and some sports equipment make up most of it. " +
					"Nothing seems to be of any real use to you right now." +					
					"\n\n" +
					"Press R to return to the bedroom\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.bedroom_0;}
	}

	void bedroom_1 ()
	{
		text.text = "You are back in the center of the bedroom. Nothing about the room feels familiar to you. " +
					"There is a closet overflowing with boxes and a door you hope leads out of " +
					"the room. There is a fishtank in the corner. " + 
					"\n\n" +
					"Press D to inspect the door\n" + 
					"Press F to inspect the fishtank\n" +
					"Press C to inspect the closet\n";
		if(Input.GetKeyDown(KeyCode.D))		{myState = States.door_1;}
		if(Input.GetKeyDown(KeyCode.F))		{myState = States.fishtank_1;}
		if(Input.GetKeyDown(KeyCode.C))		{myState = States.closet_1;}
	}

	void door_1 ()
	{
		text.text = "The door is locked, but the key you found easily slides into the " +
					"keyhole." +
					"\n\n" +
					"Press U to unlock the door\n" + 
					"Press R to return to the bedroom\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.bedroom_1;}
		if(Input.GetKeyDown(KeyCode.U))		{myState = States.hallway_0;}
	}

	void fishtank_1 ()
	{
		text.text = "You don't see any fishfood around. The fish probably haven't eaten in " +
					"weeks." +
					"\n\n" +
					"Press R to return to the bedroom\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.bedroom_1;}
	}

	void closet_1 ()
	{
		text.text = "Boxes that had been stacked in the closet seem to have fallen " +
					"over, spilling thier contents everywhere. Clothing, photos of people " +
					"you do not recognize, and some sports equipment make up most of it. " +
					"Nothing seems to be of any real use to you right now." +
					"\n\n" +
					"Press R to return to the bedroom\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.bedroom_1;}
	}

	void hallway_0 ()
	{
		text.text = "You step into the a long, rundown hallway. The ceiling is leaking " +
					"in multiple places, the floor is concrete, and the walls are plated with " +
					"rusting metal. This is nothing like the bedroom you were in. What could this " +
					"place be? You see three doors and a hatch in the ceiling at the end of the hall." +
					"\n\n" +
					"Press 1 to inspect door #1\n" + 
					"Press 2 to inspect door #2\n" +
					"Press 3 to inspect door #3\n" +
					"Press H to inspect the hatch\n";
		if(Input.GetKeyDown(KeyCode.Alpha1))		{myState = States.h_door_0_0;}
		if(Input.GetKeyDown(KeyCode.Alpha2))		{myState = States.h_door_1_0;}
		if(Input.GetKeyDown(KeyCode.Alpha3))		{myState = States.h_door_2_0;}
		if(Input.GetKeyDown(KeyCode.H))				{myState = States.hatch_0;}
	}
	
	void h_door_0_0 ()
	{
		text.text = "The door has a sign on it that reads \"Watch Your Step\". The door "  +
					"does not seem to be locked." +
					"\n\n" +
					"Press O to open door #1\n" + 
					"Press R to return to the hallway\n";
		if(Input.GetKeyDown(KeyCode.O))		{myState = States.cliff_0;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_0;}
	}

	void h_door_1_0 ()
	{
		text.text = "The door is not locked or labeled. As you touch the handle you step back " +
					"and ponder life." +
					"\n\n" +
					"Press O to open door #2\n" + 
					"Press R to return to the hallway\n";
		if(Input.GetKeyDown(KeyCode.O))		{myState = States.empty_room_0;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_0;}
	}

	void h_door_2_0 ()
	{
		text.text = "A plaque to the right of the door reads \"Janitorial\". The door is not " +
					"locked." +
					"\n\n" +
					"Press O to open door #3\n" + 
					"Press R to return to the hallway\n";
		if(Input.GetKeyDown(KeyCode.O))		{myState = States.utility_closet_0;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_0;}
	}

	void h_door_0_1 ()
	{
		text.text = "The door has a sign on it that reads \"Watch Your Step\". The door "  +
					"does not seem to be locked." +
					"\n\n" +
					"Press O to open door #1\n" + 
					"Press R to return to the hallway\n";
		if(Input.GetKeyDown(KeyCode.O))		{myState = States.cliff_1;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_1;}
	}

	void h_door_1_1 ()
	{
		text.text = "The door is not locked or labeled. As you touch the handle you step back " +
					"and ponder life." +
					"\n\n" +
					"Press O to open door #2\n" + 
					"Press R to return to the hallway\n";
		if(Input.GetKeyDown(KeyCode.O))		{myState = States.empty_room_1;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_1;}
	}

	void h_door_2_1 ()
	{
		text.text = "A plaque to the right of the door reads \"Janitorial\". The door is not " +
					"locked." +
					"\n\n" +
					"Press O to open door #3\n" + 
					"Press R to return to the hallway\n";
		if(Input.GetKeyDown(KeyCode.O))		{myState = States.utility_closet_1;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_1;}
	}

	void hatch_0 ()
	{
		text.text = "There is a latch in the ceiling here with a handle to pull it down. You jump to " +
					"grab it, but it is still out of reach." +
					"\n\n" +
					"Press R to return to the hallway\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_0;}
	}

	void cliff_0 ()
	{
		text.text = "You open the door and find it leads to a dead fall off the side of the " +
					"building. You seem to be several hundred feet from the ground. You can't " +
					"find anything to climb on to get down. At least it is a beautiful day outside." +
					"\n\n" +
					"Press R to return to the room\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.h_door_0_0;}
	}

	void empty_room_0 ()
	{
		text.text = "You open the door to find a vast, empty room. It is brightly lit and all " +
					"surfaces are bright white. For some reason, you begin to feel insignificant. " +
					"\n\n" +
					"Press R to return to the room\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.h_door_1_0;}
	}

	void cliff_1 ()
	{
		text.text = "You open the door and find it leads to a dead fall off the side of the " +
					"building. You seem to be several hundred feet from the ground. The ladder " +
					"won't quite reach the ground." +
					"\n\n" +
					"Press R to return to the room\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.h_door_0_1;}
	}

	void empty_room_1 ()
	{
		text.text = "You open the door to find a vast, empty room. It is brightly lit and all " +
					"surfaces are bright white. Having the ladder comforts you. " +
					"\n\n" +
					"Press R to return to the room\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.h_door_1_1;}
	}

	void utility_closet_0 ()
	{
		text.text = "It's a messy utility closet filled with useless parts and cleaning materials. " +
					"There is a calendar on the wall with fish on it - Is it really May already? " +
					"Tucked away in the corner you see a ladder." +
					"\n\n" +
					"Press T to take the ladder\n" + 
					"Press R to return to the room\n";
		if(Input.GetKeyDown(KeyCode.T))		{myState = States.utility_closet_1;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.h_door_2_0;}
	}

	void utility_closet_1 ()
	{
		text.text = "It's a messy utility closet filled with useless parts and cleaning materials. " +
					"There is a calendar on the wall with fish on it - Is it really May already? " +
					"\n\n" +
					"Press R to return to the room\n";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.h_door_2_1;}
	}

	void hallway_1 ()
	{
		text.text = "You step into the a long, rundown hallway. The ceiling is leaking " +
					"in multiple places, the floor is concrete, and the walls are plated with " +
					"rusting metal. This is nothing like the bedroom you were in. What could this " +
					"place be? You see three doors and a hatch in the ceiling at the end of the hall." +
					"\n\n" +
					"Press 1 to inspect door #1\n" + 
					"Press 2 to inspect door #2\n" +
					"Press 3 to inspect door #3\n" +
					"Press H to inspect the hatch\n";
		if(Input.GetKeyDown(KeyCode.Alpha1))		{myState = States.h_door_0_1;}
		if(Input.GetKeyDown(KeyCode.Alpha2))		{myState = States.h_door_1_1;}
		if(Input.GetKeyDown(KeyCode.Alpha3))		{myState = States.h_door_2_1;}
		if(Input.GetKeyDown(KeyCode.H))				{myState = States.hatch_1;}
	}

	void hatch_1 ()
	{
		text.text = "You set up the ladder beneath the hatch and climb up. You can " +
					"easily reach the handle now." +
					"\n\n" +
					"Press C to climb into the hatch\n" + 
					"Press R to return to the room\n";
		if(Input.GetKeyDown(KeyCode.C))		{myState = States.end;}
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.hallway_1;}
	}

	void end ()
	{
		text.text = "You pull down the hatch and and climb through it. The enterance is draped " +
					"with soft cloth. As you fight through it, you feel your eyes getting heavy " +
					"and suddenly the hatch closes shut behind you. Your surroundings are pitch " +
					"black. You are laying on a soft surface and feel your eyes closing. You drift " +
					"off to sleep." +
					"\n\n" +
					"Press W to wake up\n";
		if(Input.GetKeyDown(KeyCode.W))		{myState = States.bedroom_0;}
	}

}
