using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public bool hintsShown = false;



	// Use this for initialization
	void Start () 
	{
		this.GetComponent<GUIText>().text = "Press x for hints";//"WASD controls camera\nRight click to select and deselect\nOnce Selected, click or hold the left mouse button down to set a 'waypoint'\nA waypoint above the object will make it jump\nA waypoint to the side will make it go left or right\nThere is currently a bug with the rotation, sorry\nPress x to close this";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x"))
						hintsShown = !hintsShown;
		if (hintsShown)
						this.GetComponent<GUIText>().text = "WASD controls camera\nRight click selects/deselects units\nSelected units follow waypoints\nWaypoints are set with left click\nTouch voodoo enemies to kill them\nVoodo enemies kill with magic\nUnits spawn periodically\nGet to the other side";
		else
						this.GetComponent<GUIText>().text = "Press x for hints";
	}
}
