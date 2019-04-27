using UnityEngine;
using System.Collections;

public class animationMages : MonoBehaviour {
	int counter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		counter++;
		if (counter >= 600)
		{
			Vector3 position = this.transform.position;
			position.x += .02f;
			this.transform.position = position;
		}
	}
}
